﻿VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Из-з сильных ливней началось наводнение, наше жилье затопило. Моя семья вне опасности, но кошка пропала. Как поступить?
* [Броситься искать кошку с риском для жизни, несмотря на то, что я плохо плаваю]
    -> res1
* [У кошки 9 жизней, она сама спасется, а я плохо плаваю]
    -> res2
* [Я плохо плаваю. Предложить желающим из числа моей семьи спасать кошку]
    -> res3


=== res1 === 
Я чуть не утонул, но кошку нашу спас - она меня еще и поцарапала
~TextForLog = "Из-з сильных ливней началось наводнение, наше жилье затопило. Мы все спаслись, но пропала кошка. Я бросился и спаса ее, несмотря на то, что плохо плаваю."
* [Ok]
-> END
=== res2 === 
Зря я понадеялся. Больше мы нашу кошку не видели
~TextForLog = "Из-з сильных ливней началось наводнение, наше жилье затопило. Мы все спаслись, но пропала кошка. Мы понадеялись, что она найдется, но этого не произошло. Кошка погибла."
* [Ok]
-> END
=== res3 === 
Никто не решился спасать кошку. К сожалению, она погибла. Грустно
~TextForLog = "Из-з сильных ливней началось наводнение, наше жилье затопило. Мы все спаслись, но пропала кошка. Я плохо плаваю, поэтому предложил другим членам семьи найти кошку. Никто не согласился и кошка погибла."
* [Ok]
-> END