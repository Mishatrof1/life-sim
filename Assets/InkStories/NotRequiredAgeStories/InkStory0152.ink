VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я увидел свежую царапину на своей машине. Посмотрев запись с ближайшей видеокамеры, я выяснил, кто виновен. Что делать?
* [Я знаю, где он паркуется. Поцарапаю в отместку его машину]
    -> res1
* [Прощу его, хоть он и покинул место ДТП]
    -> res2
* [Сообщу в полицию и добьюсь максимальных неприятностей для негодяя]
    -> res3
* [Потребую у виновника денежной компенсации]
    -> res4

=== res1 === 
Отлично, этот козел испытал те же чувства, что и я. Только он никогда не узнает, кто это сделал
~TextForLog = "На моей машине появилась свежая царапина. С помощью видеокамер я вычислил виновника. Я поцарапал его машину в отместку. Это справедливо."
* [Ok]
-> END
=== res2 === 
Когда я вижу эту царапину, мое сердце переполняется гордостью за себя. Я сумел простить! Если бы все так поступали, мир был бы лучше
~TextForLog = "На моей машине появилась свежая царапина. С помощью видеокамер я вычислил виновника, но решил его простить."
* [Ok]
-> END
=== res3 === 
После долгой волокиты, негодяй получил по заслугам, а я получил компенсацию. Зло наказано, добро восторжествовало - ради этого стоило приложить усилия
~TextForLog = "На моей машине появилась свежая царапина. С помощью видеокамер я вычислил виновника. Я его засудил, он получил по заслугам, а я получил компенсацию."
* [Ok]
-> END
=== res4 === 
Он не стал отказываться, а все сразу оплатил. Я не держу зла, на его месте я бы вряд ли поступил иначе
~TextForLog = "На моей машине появилась свежая царапина. С помощью видеокамер я вычислил виновника. Я потребовал у него денежной компенсации и он все оплатил."
* [Ok]
-> END