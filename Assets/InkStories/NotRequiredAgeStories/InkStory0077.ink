VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Во время полета, наш авиалайнер попал в зону турбулентности. Нас сильно трясет, выпали кислородные маски. Что делать?
* [Громко крикнуть: "Мы все умрем!"]
    -> res1
* [Молиться шепотом]
    -> res2
* [Найти взглядом самого трусливого пассажира и ободряюще ему улыбнуться]
    -> res3
* [Выпить успокоительное]
    -> res4

=== res1 === 
Началась паника, все орали и валялись по полу. К счастью, экипажу удалось успокоить эту стаю обезьян и мы продолжили полет
~TextForLog = "Во время полета, наш авиалайнер попал в зону турбулентности. Нас сильно трясло. Я решил пошутить и крикнул, что мы все умрем. Пассажиры впали в панику, было весело."
* [Ok]
-> END
=== res2 === 
Экипаж  пытался успокоить всех правильными словами, но мы успокоились только после того, как прекратилась болтанка
~TextForLog = "Во время полета, наш авиалайнер попал в зону турбулентности. Нас сильно трясло. Экипаж успокаивал нас как мог, пока не кончилась болтанка."
* [Ok]
-> END
=== res3 === 
Пассажир крикнул, что он только что увидел смерть, и она ему улыбнулась. Началась паника, К счастью, экипажу удалось успокоить эту стаю обезьян и мы продолжили полет
~TextForLog = "Во время полета, наш авиалайнер попал в зону турбулентности. Нас сильно трясло. Я улыбнулся труссливому пассажиру, но он оказался не трусом, а психом и устроил панику на борту."
* [Ok]
-> END
=== res4 === 
Я вскоре уснул и проснулся только на подлете к пункту назначения...
~TextForLog = "Во время полета, наш авиалайнер попал в зону турбулентности. Нас сильно трясло. Я выпил успокоительного и проспал до самой посадки."
* [Ok]
-> END