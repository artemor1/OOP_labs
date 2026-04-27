using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab_3
{
    internal class RIFF_Files
    {
        public class Header
        {
            public string chunkId;//"RIFF" (0x52494646)
            public UInt32 dataSize;//(file size) - 8
            public string typeID;//"WAVE" (0x57415645)
        }

        public class FmtChunk
        {
            public string chunkId = "fmt ";//"fmt " (0x666D7420)
            public UInt32 dataSize = 16;//16 + extra format bytes
            public ushort compressionCode = 1;//1 - 65,535
            public ushort numberOfChannels = 1;//1 - 65,535
            public UInt32 sampleRate = 44100;//1 - 0xFFFFFFFF
            public UInt32 avgBitsPerSample = 88200;//1 - 0xFFFFFFFF AvgBytesPerSec = SampleRate * BlockAlign
            public ushort blockAlign = 2;//1 - 65,535 BlockAlign = BitsPerSample / 8 * NumChannels
            public ushort bitsPerSample = 16;//1 - 65,535
            public ushort extraFormatBytes = 0;//0 - 65,535 //Всегда четное число
            public byte[] extraBytes;
        }

        public class dataChunk
        {
            public string chunkId;//"data" (0x64617461)
            public UInt32 dataSize;
            public long dataOffset;
        }

        public class Wave
        {
            public Header header = new Header();
            public FmtChunk fmtChunk = new FmtChunk();
            public dataChunk dataChunk = new dataChunk();
            public List<dataChunk> unknownChunks = new List<dataChunk>();

            public int sampleSize = 16;

            public object channels = new object();
        }

        public class WaveReader
        {
            public static FmtChunk ReadFmtChunk(BinaryReader stream)
            {
                Debug.WriteLine("[WaveReader.ReadFmtChunk] Start reading fmt chunk");
                var chunk = new FmtChunk();
                chunk.chunkId = "fmt ";
                chunk.dataSize = stream.ReadUInt32();
                chunk.compressionCode = stream.ReadUInt16();
                chunk.numberOfChannels = stream.ReadUInt16();
                chunk.sampleRate = stream.ReadUInt32();
                chunk.avgBitsPerSample = stream.ReadUInt32();
                chunk.blockAlign = stream.ReadUInt16();
                chunk.bitsPerSample = stream.ReadUInt16();
                if (chunk.dataSize > 16)
                {
                    chunk.extraFormatBytes = stream.ReadUInt16();
                    if ((chunk.extraFormatBytes & 1) == 1) chunk.numberOfChannels++;
                    chunk.extraBytes = stream.ReadBytes(chunk.extraFormatBytes);
                }
                Debug.WriteLine($"[WaveReader.ReadFmtChunk] Completed. sampleRate={chunk.sampleRate}, channels={chunk.numberOfChannels}, bits={chunk.bitsPerSample}");
                return chunk;
            }
            public static dataChunk ReadDataChunk(BinaryReader stream, string id)
            {
                Debug.WriteLine($"[WaveReader.ReadDataChunk] Start chunkId={id}");
                var chunk = new dataChunk();
                chunk.chunkId = id;
                chunk.dataSize = stream.ReadUInt32();
                chunk.dataOffset = stream.BaseStream.Position;
                stream.BaseStream.Position += chunk.dataSize;
                Debug.WriteLine($"[WaveReader.ReadDataChunk] Completed chunkId={id}, dataSize={chunk.dataSize}, dataOffset={chunk.dataOffset}");
                return chunk;
            }
            public static Wave ReadWaveFile(string path)
            {
                Debug.WriteLine($"[WaveReader.ReadWaveFile] Start path={path}");
                var br = new BinaryReader(File.Open(path, FileMode.Open));
                var res = new Wave();
                try
                {
                    using (br)
                    {
                        //Чтение заголовка и проверка соответствия формата
                        Header h = new Header();
                        h.chunkId = Encoding.UTF8.GetString(br.ReadBytes(4));
                        if (h.chunkId != "RIFF") { throw new Exception("It's not a wave file"); }
                        h.dataSize = br.ReadUInt32();
                        h.typeID = Encoding.UTF8.GetString(br.ReadBytes(4));
                        if (h.typeID != "WAVE") { throw new Exception("It's not a wave file"); }
                        int checkValue = 0;

                        FmtChunk fmtChunk = new FmtChunk();
                        dataChunk dataChunk = new dataChunk();
                        List<dataChunk> unknownChunks = new List<dataChunk>();
                        //Чтение секций
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            string chunkId = Encoding.UTF8.GetString(br.ReadBytes(4));
                            switch (chunkId)
                            {
                                case "fmt ":
                                    fmtChunk = ReadFmtChunk(br);
                                    checkValue++;
                                    break;
                                case "data":
                                    dataChunk = ReadDataChunk(br, chunkId);
                                    checkValue++;
                                    break;
                                default:
                                    var dat = ReadDataChunk(br, chunkId);
                                    unknownChunks.Add(dat);
                                    break;
                            }
                        }
                        if (checkValue < 2) throw new Exception("Не все обязательные секции прочитаны");
                        res.header = h;
                        res.fmtChunk = fmtChunk;
                        res.dataChunk = dataChunk;
                        //Чтение данных
                        //var samples_total = dataChunk.dataSize / (fmtChunk.signBitsPerSample / 8);
                        br.BaseStream.Position = dataChunk.dataOffset;
                        var buf = br.ReadBytes((int)dataChunk.dataSize);
                        if (fmtChunk.bitsPerSample == 8)
                            res.channels = ReadChanels<byte>(buf, fmtChunk);
                        else res.channels = ReadChanels<short>(buf, fmtChunk);
                        Debug.WriteLine($"[WaveReader.ReadWaveFile] Completed path={path}, bits={fmtChunk.bitsPerSample}, channels={fmtChunk.numberOfChannels}");
                        return res;
                    }
                }
                catch (Exception ex) { br.Close(); throw new Exception("", ex); }
                finally
                {
                    br.Close();
                }
            }
            private static List<T[]> ReadChanels<T>(byte[] buf, FmtChunk fmt)
            {
                Debug.WriteLine($"[WaveReader.ReadChanels] Start type={typeof(T).Name}, byteCount={buf.Length}, channels={fmt.numberOfChannels}");
                List<T[]> res = new List<T[]>();
                var samples_total = buf.Length / fmt.bitsPerSample * 8;
                T[] arr = new T[samples_total];
                Buffer.BlockCopy(buf, 0, arr, 0, buf.Length);
                if (fmt.numberOfChannels == 1)
                {
                    res.Add(arr);
                }
                else
                {
                    int i = fmt.numberOfChannels;
                    var samples_per_channel = samples_total / fmt.numberOfChannels;
                    while (i > 0) { res.Add(new T[samples_per_channel]); i--; }
                    i = 0;
                    int k = 0;
                    while (i < samples_total)
                    {
                        for (int c = 0; c < fmt.numberOfChannels; c++)
                        {
                            res[c][k] = arr[i++];
                        }
                        k++;
                    }
                }
                Debug.WriteLine($"[WaveReader.ReadChanels] Completed. outputChannels={res.Count}, samplesPerChannel={(res.Count > 0 ? res[0].Length : 0)}");
                return res;

            }
            public static int WriteWaveFile<T>(string path, FmtChunk fmt, List<T[]> channels)
            {
                Debug.WriteLine($"[WaveReader.WriteWaveFile] Start path={path}, channelCount={(channels == null ? 0 : channels.Count)}");
                var bw = new BinaryWriter(File.Create(path));
                try
                {
                    //Вычисление параметров
                    fmt.bitsPerSample = 16;
                    var fmtSize = 16;
                    if (fmt.extraFormatBytes > 0) fmtSize += 2 + fmt.extraBytes.Length;
                    int dataSize = 0;
                    foreach (var v in channels)
                    {
                        dataSize += v.Count<T>() * 2;
                    }
                    //Формирование массива данных
                    byte[] buf = new byte[dataSize];
                    int channelCount = channels.Count;
                    int count = channels[0].Count();
                    int shift = 0;
                    for (int i = 0; i < count; i++)
                    {
                        for (int ch = 0; ch < channelCount; ch++)
                        {
                            var arr = BitConverter.GetBytes(Convert.ToInt16(channels[ch][i]));
                            buf[shift++] = arr[0];
                            buf[shift++] = arr[1];
                        }
                    }
                    uint fileSize = (uint)(12 + 8 + fmtSize + 8 + dataSize);
                    fmt.numberOfChannels = (ushort)channelCount;
                    fmt.blockAlign = (ushort)(fmt.bitsPerSample / 8 * fmt.numberOfChannels);
                    fmt.avgBitsPerSample = (UInt32)(fmt.sampleRate * fmt.blockAlign);
                    fmt.compressionCode = 1;
                    //Запись массива
                    using (bw)
                    {
                        //Header
                        bw.Write(Encoding.UTF8.GetBytes("RIFF"));//chunkId;
                                                                 //"RIFF" (0x52494646)
                        bw.Write(fileSize - 8);//dataSize;//(file size) - 8
                        bw.Write(Encoding.UTF8.GetBytes("WAVE"));//typeID;
                                                                 //"WAVE" (0x57415645)
                                                                 //fmt chunk
                        bw.Write(Encoding.UTF8.GetBytes("fmt "));
                        //string chunkId = "fmt ";//"fmt " (0x666D7420)
                        bw.Write(fmt.dataSize);//UInt32 dataSize = 16;
                                               //16 + extra format bytes
                        bw.Write(fmt.compressionCode);//ushort compressionCode = 1;
                                                      //1 - 65,535
                        bw.Write(fmt.numberOfChannels);//ushort numberOfChannels = 1;
                                                       //1 - 65,535
                        bw.Write(fmt.sampleRate);//UInt32 sampleRate = 44100;
                                                 //1 - 0xFFFFFFFF
                        bw.Write(fmt.avgBitsPerSample);
                        //UInt32 avgBitsPerSample = 88200;
                        //1 - 0xFFFFFFFF AvgBytesPerSec = SampleRate * BlockAlign
                        bw.Write(fmt.blockAlign);
                        //ushort blockAlign = 2;
                        //1 - 65,535 BlockAlign = BitsPerSample / 8 * NumChannels
                        bw.Write(fmt.bitsPerSample);
                        //ushort bitsPerSample = 16;
                        //1 - 0xFFFFFFFF
                        if (fmt.extraFormatBytes > 0)
                        {
                            bw.Write(fmt.extraFormatBytes);
                            //ushort extraFormatBytes = 0;
                            //0 - 65,535 //Всегда четное число
                            bw.Write(fmt.extraBytes);//byte[] extraBytes;
                            if ((fmt.extraBytes.Length & 0x01) == 1) bw.Write((byte)0);
                        }
                        //data chunk
                        bw.Write(Encoding.UTF8.GetBytes("data"));
                        //string chunkId;//"data" (0x64617461)
                        bw.Write(dataSize);//UInt32 dataSize
                        bw.Write(buf);
                    }
                    Debug.WriteLine($"[WaveReader.WriteWaveFile] Completed path={path}, dataSize={dataSize}, channels={channelCount}");
                    return 0;
                }
                catch (Exception ex)
                {
                    bw.Close();
                    throw new Exception("Error Write wav", ex);
                }
                finally
                {
                    bw.Close();
                }
            }

            public static double[] LoadSignalData(string path)
            {
                Debug.WriteLine($"[WaveReader.LoadSignalData] Start path={path}");
                var wav = ReadWaveFile(path);
                var type = wav.channels.GetType();

                if (type.Equals(typeof(List<byte[]>)))
                {
                    var dat = wav.channels as List<byte[]>;
                    var result = Array.ConvertAll(dat[0], target => Convert.ToDouble(target));
                    Debug.WriteLine($"[WaveReader.LoadSignalData] Completed byte-based load. length={result.Length}");
                    return result;
                }

                if (type.Equals(typeof(List<short[]>)))
                {
                    var dat = wav.channels as List<short[]>;
                    var result = Array.ConvertAll(dat[0], target => Convert.ToDouble(target));
                    Debug.WriteLine($"[WaveReader.LoadSignalData] Completed short-based load. length={result.Length}");
                    return result;
                }

                Debug.WriteLine($"[WaveReader.LoadSignalData] Unsupported channel storage type={type}");
                return null;
            }

            private void loadSignalFromFileToolStripMenuItem_Click(object sender, EventArgs e)
            {
                var f1 = new Form1();
                var ofd = new OpenFileDialog();
                ofd.Filter = "Text files|*.txt|Wave files|*.wav";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string ext = System.IO.Path.GetExtension(ofd.FileName);
                switch (ext)
                {
                    case ".txt":
                        var data =
                   File_IO_Methods.LoadDataFromTxtFile(ofd.FileName);
                        if (data == null) return;
                        f1.signalData = data.ToArray();
                        break;
                    case ".wav":
                        f1.signalData = RIFF_Files.WaveReader.LoadSignalData(ofd.FileName);
                        break;
                    default: break;
                }
            }


        }



    }
}
