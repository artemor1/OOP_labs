# -*- coding: utf-8 -*-
"""Generate Lab 3 report as .docx without external dependencies."""
import zipfile
import os
from xml.sax.saxutils import escape

OUTPUT = os.path.join(os.path.dirname(__file__), "Отчет_Lab3.docx")

def para(text, bold=False):
    t = escape(text)
    if bold:
        return f'<w:p><w:pPr><w:spacing w:after="120"/></w:pPr><w:r><w:rPr><w:b/></w:rPr><w:t xml:space="preserve">{t}</w:t></w:r></w:p>'
    return f'<w:p><w:pPr><w:spacing w:after="80"/></w:pPr><w:r><w:t xml:space="preserve">{t}</w:t></w:r></w:p>'

def heading(text, level=1):
    sz = "28" if level == 1 else "24"
    return (
        f'<w:p><w:pPr><w:spacing w:before="240" w:after="120"/>'
        f'<w:pStyle w:val="Heading{level}"/></w:pPr>'
        f'<w:r><w:rPr><w:b/><w:sz w:val="{sz}"/></w:rPr>'
        f'<w:t xml:space="preserve">{escape(text)}</w:t></w:r></w:p>'
    )

sections = []

sections.append(heading("ОТЧЁТ по лабораторной работе №3", 1))
sections.append(para("Применение ООП в задачах обработки сигналов"))
sections.append(para("Выполнил: Филимонов Артём, РСК-21"))
sections.append(para("Проект: Lab 3 (Windows Forms, C#, .NET Framework 4.7.2)"))
sections.append(para(""))

sections.append(heading("Общая структура проекта", 2))
sections.append(para("Основные классы: File_IO_Methods, Histogram, SignalStatistics, Generator, FourierTransform, Correlation, MLS, Filtering, VariantSignalGenerator, RIFF_Files.WaveReader, MyGraphics."))
sections.append(para("Визуализация: ZedGraph (zedGraphControl1 — сигнал, zedGraphControl2 — спектр/гистограмма, zedGraphControl3 — обработанный сигнал/АКФ)."))
sections.append(para(""))

# Task 1
sections.append(heading("Задание 1. Преобразование чисел в бинарный файл", 2))
sections.append(para("Создание текстового файла со списком вещественных чисел и записи их в бинарный формат (п. 3.2).", bold=True))
sections.append(para(""))
sections.append(para("Класс File_IO_Methods (FileIO.cs):", bold=True))
sections.append(para("• SaveDataToTxtFile(List<double> data, string path) — сохранение чисел в текстовый файл"))
sections.append(para("• LoadDataFromTxtFile(string path) — чтение чисел из текстового файла"))
sections.append(para("• SaveDataToBinFile(List<double> data, string path) — записывает double[] в бинарный файл (BinaryWriter)"))
sections.append(para("• LoadDataFromBinFile(string path) — читает double[] из бинарного файла (BinaryReader)"))
sections.append(para(""))
sections.append(para("GUI (меню File):", bold=True))
sections.append(para("• Load — загрузка .txt или .bin в dataGridView1 (методы LoadData, totxtToolStripMenuItem_Click не используются для signalData)"))
sections.append(para("• Save → To TXT / To BIN — сохранение текущего signalData в файл (tobinToolStripMenuItem_Click, totxtToolStripMenuItem_Click)"))
sections.append(para(""))
sections.append(para("Примечание: загрузка сигнала для анализа — File → Load signal from file (только .txt/.wav, не .bin). Для задания 1 используйте File → Load (.txt/.bin) и Save → To BIN."))

# Task 2
sections.append(heading("Задание 2. Гистограмма и статистические показатели", 2))
sections.append(para("Визуализация данных из бинарного файла, гистограмма, СКО, дисперсия (п. 3.3).", bold=True))
sections.append(para(""))
sections.append(para("Класс Histogram (Histogram.cs):", bold=True))
sections.append(para("• CalcHistogram(double[] data) — вычисляет гистограмму (поля intervars, min, max, step)"))
sections.append(para(""))
sections.append(para("Класс SignalStatistics (SignalStatistics.cs):", bold=True))
sections.append(para("• Calculate(double[] source) — возвращает SignalStatisticsResult: Count, Mean, Variance, StandardDeviation (СКО), Min, Max, Range"))
sections.append(para(""))
sections.append(para("Класс MyGraphics:", bold=True))
sections.append(para("• DrawGraph(zgc, data, GraphType.stick) — отрисовка гистограммы на zedGraphControl2"))
sections.append(para(""))
sections.append(para("GUI:", bold=True))
sections.append(para("• Histogram → Calc — CalculateHistogram()"))
sections.append(para("• Histogram → Show — свойства гистограммы в PropertyGrid (checkBox2)"))
sections.append(para("• Чекбокс «Statistics» (cbStat) — ShowStatisticProperties(), расчёт SignalStatistics.Calculate для signalData или processedSignalData"))
sections.append(para(""))
sections.append(para("Порядок: загрузить данные (из .bin через File → Load), перенести в signalData (Load signal / генерация), затем Calc гистограммы и Statistics."))

# Task 3
sections.append(heading("Задание 3. Исследование спектров при разной размерности", 2))
sections.append(para("Генерация различных сигналов и анализ спектров в зависимости от размерности (п. 3.4).", bold=True))
sections.append(para(""))
sections.append(para("Класс Generator (SignalGenerator.cs):", bold=True))
sections.append(para("• GenSin(int periods) — синусоида; periods задаёт число кодовых интервалов (размерность/длина)"))
sections.append(para("• GenRandomSignal(int periods) — равномерный случайный сигнал"))
sections.append(para("• GenNormalSignal(int periods) — нормально распределённый сигнал"))
sections.append(para("• GenerateSignal(MyComplexSignal) — генерация по signalType (sinus, random, normal, AM, FM, PhM)"))
sections.append(para("• Параметры: samples, FreqSampling, Duration, carrierFrequency — влияют на длину и частоту"))
sections.append(para(""))
sections.append(para("Класс FourierTransform (Fourier.cs):", bold=True))
sections.append(para("• Double2Complex, FT(Complex[], dir), AmplSpectrum — ДПФ и амплитудный спектр"))
sections.append(para("• AmplSpectrum(double[]) — спектр через FFT AForge"))
sections.append(para(""))
sections.append(para("Класс Spectrum + WindowFunction:", bold=True))
sections.append(para("• Spectrum.CalculateSpectrumWindow — оконное преобразование Фурье"))
sections.append(para("• Spectrum.CalculateSpectrumWindowParallel — параллельный вариант"))
sections.append(para("• WindowFunction.GenHammingWindow, GenBlackmanWindow"))
sections.append(para(""))
sections.append(para("GUI:", bold=True))
sections.append(para("• Generator → Random / Normal / Sin / AM / FM / PhM"))
sections.append(para("• Fourier → FFT — ShowFftSpectrum()"))
sections.append(para("• Fourier → Windowed spectrum → Hamming / Blackman parallel — ShowWindowedSpectrum()"))
sections.append(para("• Generator → Show properties (checkBox1) — настройка FreqSampling, Duration, samples"))

# Task 4
sections.append(heading("Задание 4. Амплитудный спектр и АКФ сигналов", 2))
sections.append(para("Генерация сигналов, амплитудный спектр и АКФ, графический вывод (п. 3.4.1).", bold=True))
sections.append(para(""))
sections.append(para("Функции:", bold=True))
sections.append(para("• FourierTransform.FT + AmplSpectrum — амплитудный спектр"))
sections.append(para("• Correlation.Akf(double[] s) — циклическая АКФ"))
sections.append(para("• Correlation.Akf_acycle(double[] s) — ациклическая АКФ"))
sections.append(para("• Generator — генерация тестовых сигналов"))
sections.append(para("• MyGraphics.DrawGraph — отрисовка на zedGraphControl1 (сигнал), zedGraphControl2 (спектр), zedGraphControl3 (АКФ)"))
sections.append(para(""))
sections.append(para("GUI:", bold=True))
sections.append(para("• Fourier → FFT"))
sections.append(para("• Correlation → AKF / AKF Acycle"))
sections.append(para("• Generator → генерация сигналов"))

# Task 5
sections.append(heading("Задание 5. М-последовательность, спектр, АКФ, согласованный фильтр", 2))
sections.append(para("М-последовательность, спектр, АКФ, максимумы, согласованная фильтрация (п. 3.4.2, 3.4.3).", bold=True))
sections.append(para(""))
sections.append(para("Класс MLS (MLS.cs):", bold=True))
sections.append(para("• MakeMSequence(int[] polinom) — генерация М-последовательности по коэффициентам полинома (±1)"))
sections.append(para(""))
sections.append(para("Класс Filtering (MatchedFilter.cs):", bold=True))
sections.append(para("• GenTestSignal(int[] polinom, List<int> shifts) — тестовый сигнал с вставками М-последовательности"))
sections.append(para("• MatchedFilter(int[] signal, int[] seq) — согласованная фильтрация"))
sections.append(para("• FindMax(double[] signal, double threshold) — поиск максимумов (пики корреляции)"))
sections.append(para(""))
sections.append(para("Также: FourierTransform.AmplSpectrum, Correlation.Akf для спектра и АКФ М-последовательности."))
sections.append(para(""))
sections.append(para("GUI:", bold=True))
sections.append(para("• MLS Sequence — GenerateMlsSequence() (полином жёстко задан: {1,0,1,1})"))
sections.append(para("• Matched Filter — ApplyMatchedFiltering() (демо с полиномом {1,0,1,1})"))
sections.append(para("• Fourier → Matched filter demo — RunMatchedFilterDemo() (полином {1,0,0,1}, сдвиги 8,24,40)"))
sections.append(para(""))
sections.append(para("⚠ ОТСУТСТВУЕТ в GUI:", bold=True))
sections.append(para("• Выбор номера варианта полинома (1–15 из таблицы задания) — полином задаётся только в коде"))
sections.append(para("• Создание нескольких М-последовательностей с разными полиномами через интерфейс"))
sections.append(para("• Явный выбор одной М-последовательности как импульсной характеристики фильтра"))
sections.append(para("• Автоматическое определение сигнала с максимальной мерой схожести для всех сигналов"))

# Task 6
sections.append(heading("Задание 6. Вариантный сигнал u = A(t)·cos(ω(t)·t + φ(t))", 2))
sections.append(para("Спектральные и корреляционные характеристики сигнала по номеру варианта (п. 3.4.4).", bold=True))
sections.append(para(""))
sections.append(para("Класс VariantSignalGenerator (VariantSignalGenerator.cs):", bold=True))
sections.append(para("• GetVariants() — список вариантов 1–30"))
sections.append(para("• Describe(int variant) — описание параметров A(t), ω(t), φ(t)"))
sections.append(para("• Generate(int variant, int samplingFrequency, double durationSeconds) — генерация сигнала"))
sections.append(para("• GetAmplitude, GetOmega, GetPhi (private) — параметры по варианту"))
sections.append(para(""))
sections.append(para("Для спектра и АКФ: FourierTransform, Correlation.Akf, MyGraphics."))
sections.append(para(""))
sections.append(para("GUI:", bold=True))
sections.append(para("• Generator → Variant signals (1–8) — только варианты 1–8 (ConfigureAdditionalMenus)"))
sections.append(para(""))
sections.append(para("⚠ ОТСУТСТВУЕТ в GUI:", bold=True))
sections.append(para("• Выбор вариантов 9–30 (реализованы в коде, но не добавлены в меню)"))
sections.append(para("• Поле ввода номера варианта пользователя"))

# Task 7
sections.append(heading("Задание 7. Генератор с привязкой к частоте дискретизации, WAV, сравнение с Winaur", 2))
sections.append(para("Методы генератора с Fs, запис в файл, просмотр в Winaur, спектр и АКФ (п. 3.4).", bold=True))
sections.append(para(""))
sections.append(para("Класс Generator — параметры с привязкой к Fs:", bold=True))
sections.append(para("• FreqSampling / samplingFrequency — частота дискретизации (Гц)"))
sections.append(para("• Duration — длительность сигнала (с)"))
sections.append(para("• samples = FreqSampling × Duration — число отсчётов"))
sections.append(para("• GenSin, GenRandomSignal, GenNormalSignal, GenAM, GenFM, GenPhM — используют samplingFrequency"))
sections.append(para(""))
sections.append(para("Класс VariantSignalGenerator.Generate(variant, samplingFrequency, duration) — задание 6 с Fs."))
sections.append(para(""))
sections.append(para("Класс RIFF_Files.WaveReader:", bold=True))
sections.append(para("• SaveSignalData(string path, double[] signal, uint sampleRate) — сохранение сигнала в WAV (нормализация в int16)"))
sections.append(para("• WriteWaveFile<T>(path, FmtChunk, List<T[]> channels) — запис WAV-файла"))
sections.append(para("• ReadWaveFile, LoadSignalData — чтение WAV"))
sections.append(para(""))
sections.append(para("Form1:", bold=True))
sections.append(para("• SaveSignalToWav() — диалог сохранения, использует generator.FreqSampling как частоту дискретизации"))
sections.append(para(""))
sections.append(para("MyGraphics.DrawGraph(..., freqSampling) — ось времени/частоты с учётом Fs."))
sections.append(para(""))
sections.append(para("GUI:", bold=True))
sections.append(para("• File → Save → To .wav — сохранение signalData в WAV (towavToolStripMenuItem_Click)"))
sections.append(para("• Generator → Show properties — FreqSampling, Duration в PropertyGrid"))
sections.append(para("• File → Load signal from file — загрузка .wav"))
sections.append(para("• Fourier → FFT, Correlation → AKF — спектр и АКФ для сравнения"))
sections.append(para(""))
sections.append(para("⚠ ОТСУТСТВУЕТ в GUI:", bold=True))
sections.append(para("• Прямое сравнение результатов с Winaur в приложении (сравнение выполняется вручную во внешней программе)"))

# Summary table
sections.append(heading("Сводная таблица: функции и GUI по заданиям", 2))
sections.append(para("Задание 1 — File_IO_Methods: Save/Load TXT/BIN — GUI: File Load, Save To TXT/BIN — ✓"))
sections.append(para("Задание 2 — Histogram.CalcHistogram, SignalStatistics.Calculate — GUI: Histogram Calc, Statistics — ✓"))
sections.append(para("Задание 3 — Generator, FourierTransform, Spectrum — GUI: Generator, FFT, Windowed spectrum — ✓"))
sections.append(para("Задание 4 — FourierTransform, Correlation.Akf — GUI: FFT, AKF — ✓"))
sections.append(para("Задание 5 — MLS, Filtering — GUI: MLS, Matched Filter — частично (нет выбора полинома)"))
sections.append(para("Задание 6 — VariantSignalGenerator — GUI: варианты 1–8 — частично (9–30 только в коде)"))
sections.append(para("Задание 7 — Generator+Fs, WaveReader.SaveSignalData — GUI: Save To WAV, Fs, загрузка WAV — ✓ (сравнение с Winaur вручную)"))

sections.append(para(""))
sections.append(para("— Конец отчёта —"))

document_xml = (
    '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>'
    '<w:document xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">'
    '<w:body>'
    + ''.join(sections)
    + '<w:sectPr><w:pgSz w:w="11906" w:h="16838"/>'
    '<w:pgMar w:top="1134" w:right="850" w:bottom="1134" w:left="1701"/></w:sectPr>'
    '</w:body></w:document>'
)

content_types = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
<Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
<Default Extension="xml" ContentType="application/xml"/>
<Override PartName="/word/document.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"/>
</Types>'''

rels = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
<Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml"/>
</Relationships>'''

doc_rels = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships"/>'''

with zipfile.ZipFile(OUTPUT, 'w', zipfile.ZIP_DEFLATED) as zf:
    zf.writestr('[Content_Types].xml', content_types)
    zf.writestr('_rels/.rels', rels)
    zf.writestr('word/_rels/document.xml.rels', doc_rels)
    zf.writestr('word/document.xml', document_xml.encode('utf-8'))

print(f"Created: {OUTPUT}")
