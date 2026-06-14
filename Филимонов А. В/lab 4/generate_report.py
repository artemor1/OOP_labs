# -*- coding: utf-8 -*-
"""Generate Lab 4 report as .docx without external dependencies."""
import zipfile
import os
from xml.sax.saxutils import escape

OUTPUT = os.path.join(os.path.dirname(__file__), "Отчет_Lab4.docx")


def para(text, bold=False):
    t = escape(text)
    if bold:
        return (
            f'<w:p><w:pPr><w:spacing w:after="120"/></w:pPr>'
            f'<w:r><w:rPr><w:b/></w:rPr><w:t xml:space="preserve">{t}</w:t></w:r></w:p>'
        )
    return (
        f'<w:p><w:pPr><w:spacing w:after="80"/></w:pPr>'
        f'<w:r><w:t xml:space="preserve">{t}</w:t></w:r></w:p>'
    )


def heading(text, level=1):
    sz = "28" if level == 1 else "24"
    return (
        f'<w:p><w:pPr><w:spacing w:before="240" w:after="120"/>'
        f'<w:pStyle w:val="Heading{level}"/></w:pPr>'
        f'<w:r><w:rPr><w:b/><w:sz w:val="{sz}"/></w:rPr>'
        f'<w:t xml:space="preserve">{escape(text)}</w:t></w:r></w:p>'
    )


sections = []

# Title
sections.append(heading("ОТЧЁТ по лабораторной работе №4", 1))
sections.append(para("Обработка изображений"))
sections.append(para("Выполнил: Филимонов Артём, РСК-21"))
sections.append(para("Проект: ImageProcessingLab (Windows Forms, C#, .NET Framework 4.7.2)"))
sections.append(para(""))

# Goal
sections.append(heading("Цель работы", 2))
sections.append(para(
    "Изучить основные методы обработки изображений: фильтрацию в частотной "
    "и пространственной области, а также поиск фрагмента на изображении."
))
sections.append(para(""))

# Tools
sections.append(heading("Используемые средства", 2))
sections.append(para("Язык программирования: C#"))
sections.append(para("Среда разработки: Visual Studio"))
sections.append(para("Библиотека: AForge.NET (AForge.Math — БПФ)"))
sections.append(para("Графический интерфейс: Windows Forms"))
sections.append(para(""))
sections.append(para("Основные файлы проекта:", bold=True))
sections.append(para("• ImageActions.cs — все алгоритмы обработки"))
sections.append(para("• Form1.cs — меню и вызов функций"))
sections.append(para(""))

# Task 1
sections.append(heading("Задание 1. Фильтрация в частотной области", 2))
sections.append(para(
    "Нужно было загрузить изображение, посмотреть его спектр и убрать шум "
    "с помощью фильтра в частотной области."
))
sections.append(para(""))
sections.append(para("Что сделано:", bold=True))
sections.append(para("1. Изображение переводится в оттенки серого (Convert to Grey)."))
sections.append(para("2. Строится спектр изображения — двумерное БПФ (Show FFT Spectrum)."))
sections.append(para("3. Применяется гауссов низкочастотный фильтр (Gauss Lowpass Filter)."))
sections.append(para("4. Для сравнения есть высокочастотный фильтр (Gauss Highpass Filter)."))
sections.append(para(""))
sections.append(para("Как работает фильтр:", bold=True))
sections.append(para(
    "Изображение преобразуется в массив комплексных чисел, выполняется прямое БПФ. "
    "Затем спектр умножается на гауссов фильтр и выполняется обратное БПФ."
))
sections.append(para(
    "Низкочастотный фильтр: H(u,v) = exp(-((u-u0)² + (v-v0)²) / (2σ²)) — "
    "пропускает низкие частоты, убирает шум."
))
sections.append(para(
    "Высокочастотный фильтр: H(u,v) = 1 - exp(-((u-u0)² + (v-v0)²) / (2σ²)) — "
    "выделяет границы и мелкие детали."
))
sections.append(para(""))
sections.append(para("Параметры фильтра:", bold=True))
sections.append(para("σ (sigma) = 10 — подобрал экспериментально."))
sections.append(para("При σ = 5 шум убирается слабо, картинка почти не меняется."))
sections.append(para("При σ = 10 шум заметно уменьшается, детали ещё видны."))
sections.append(para("При σ = 20 изображение сильно размывается, теряются мелкие объекты."))
sections.append(para("Оптимальное значение для моих тестовых картинок — σ = 10."))
sections.append(para(""))
sections.append(para("Результат: после низкочастотной фильтрации шум на изображении уменьшается, картинка становится более гладкой."))
sections.append(para(""))

# Task 2
sections.append(heading("Задание 2. Фильтрация в пространственной области", 2))
sections.append(para(
    "Нужно было выполнить свёртку изображения с заданным ядром фильтра."
))
sections.append(para(""))
sections.append(para("В программе реализованы два пространственных фильтра:", bold=True))
sections.append(para(""))
sections.append(para("1. Низкочастотный фильтр (Spatial Lowpass Filter — Blur)", bold=True))
sections.append(para("Ядро 5×5 — фильтр скользящего среднего, каждый элемент = 1/25:"))
sections.append(para("  1/25  1/25  1/25  1/25  1/25"))
sections.append(para("  1/25  1/25  1/25  1/25  1/25"))
sections.append(para("  1/25  1/25  1/25  1/25  1/25"))
sections.append(para("  1/25  1/25  1/25  1/25  1/25"))
sections.append(para("  1/25  1/25  1/25  1/25  1/25"))
sections.append(para("Этот фильтр сглаживает изображение и убирает шум."))
sections.append(para(""))
sections.append(para("2. Высокочастотный фильтр (Spatial Highpass Filter — Edges)", bold=True))
sections.append(para("Ядро 3×3 — фильтр Лапласа:"))
sections.append(para("  -1  -1  -1"))
sections.append(para("  -1   8  -1"))
sections.append(para("  -1  -1  -1"))
sections.append(para("Этот фильтр находит области резкого изменения яркости (границы объектов)."))
sections.append(para(""))
sections.append(para("Алгоритм свёртки:", bold=True))
sections.append(para(
    "Для каждого пикселя берётся окно размером с ядро, вычисляется сумма "
    "произведений значений пикселей на коэффициенты ядра. Результат записывается "
    "в новое изображение."
))
sections.append(para(""))
sections.append(para("Результаты:", bold=True))
sections.append(para("• Низкочастотный фильтр — изображение размывается, шум уменьшается."))
sections.append(para("• Высокочастотный фильтр — видны контуры объектов на тёмном фоне."))
sections.append(para(""))

# Task 3
sections.append(heading("Задание 3. Поиск фрагмента изображения", 2))
sections.append(para(
    "Нужно было найти фрагмент (например, лицо) на большой фотографии."
))
sections.append(para(""))
sections.append(para("В программе есть два способа:", bold=True))
sections.append(para(""))
sections.append(para("1. Поиск в пространственной области (Find Fragment — Spatial Domain)", bold=True))
sections.append(para(
    "Загружаем большое изображение и маленький фрагмент (шаблон). "
    "Программа перебирает все возможные позиции и считает корреляцию — "
    "сумму произведений пикселей шаблона и соответствующей области изображения. "
    "Там, где корреляция максимальна — найден фрагмент."
))
sections.append(para(""))
sections.append(para("2. Поиск в частотной области (Find Fragment — Frequency Domain)", bold=True))
sections.append(para(
    "Быстрый способ через БПФ. Вычисляются спектры изображения и шаблона, "
    "спектры перемножаются, выполняется обратное БПФ. Пик в результате "
    "показывает координаты найденного фрагмента. На результате рисуется красная рамка."
))
sections.append(para(""))
sections.append(para("Как пользоваться:", bold=True))
sections.append(para("1. File → Open Image — открыть большое фото."))
sections.append(para("2. Actions → Find Fragment — выбрать файл с фрагментом (лицо, объект)."))
sections.append(para("3. Программа показывает координаты X, Y найденного места."))
sections.append(para(""))
sections.append(para(
    "Я проверял на фотографии с несколькими людьми: вырезал лицо одного человека "
    "как шаблон и искал его на общем фото. Оба метода нашли правильное место."
))
sections.append(para(""))

# Program structure
sections.append(heading("Структура программы", 2))
sections.append(para("Меню File:", bold=True))
sections.append(para("• Open Image — открыть изображение"))
sections.append(para("• Save Image — сохранить результат"))
sections.append(para(""))
sections.append(para("Меню Actions:", bold=True))
sections.append(para("• Convert to Grey — перевод в серый"))
sections.append(para("• Show FFT Spectrum — показать спектр"))
sections.append(para("• Gauss Lowpass Filter — НЧ-фильтр в частотной области"))
sections.append(para("• Gauss Highpass Filter — ВЧ-фильтр в частотной области"))
sections.append(para("• Spatial Lowpass Filter (Blur) — НЧ-фильтр в пространственной области"))
sections.append(para("• Spatial Highpass Filter (Edges) — ВЧ-фильтр (Лаплас)"))
sections.append(para("• Find Fragment (Spatial Domain) — поиск фрагмента"))
sections.append(para("• Find Fragment (Frequency Domain) — поиск через БПФ"))
sections.append(para(""))
sections.append(para("На форме две вкладки: Source Image (исходное) и Result Image (результат)."))
sections.append(para(""))

# Conclusion
sections.append(heading("Выводы", 2))
sections.append(para("В ходе работы я реализовал программу для обработки изображений на C#."))
sections.append(para("1. Фильтрация в частотной области с гауссовым фильтром (σ=10) хорошо убирает шум с изображения."))
sections.append(para("2. Пространственная фильтрация свёрткой позволяет сглаживать (НЧ) и выделять границы (ВЧ-фильтр Лапласа)."))
sections.append(para("3. Поиск фрагмента работает и в пространственной, и в частотной области. Частотный метод быстрее на больших изображениях."))
sections.append(para("4. БПФ — удобный инструмент для анализа и обработки изображений."))
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
