VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Отдыхая на побережье, я катался по заливу на SUP. Ветер вынес меня в открытое море, SUP перевернулся. Я доплыл до суши, оказалось что это необитаемый островок. Что делать?
* [Обследовать островок, действовать по обстоятельствам]
    -> res1
* [Набраться смелости и поплыть к материку]
    -> res2
* [Ждать помощи]
    -> res3
* [Звать на помощь]
    -> res4

=== res1 === 
Оказалось, остров кишит змеями. Я чудом уцелел, и помощи дожидался  уже по пояс в воде. Хорошо, что меня заметили другие люди на SUP и спасли
~TextForLog = "Волей судьбы, я оказался на необитаемом островке недалеко от материка.Островок оказался населен множеством змей. К счастью, меня заметили люди и спасли."
* [Ok]
-> END
=== res2 === 
Я плыл, пока хватало сил. А когда их уже не оставалось, меня заметили другие люди на SUP и спасли
~TextForLog = "Волей судьбы, я оказался на необитаемом островке недалеко от материка. Островок оказался населен множеством змей. Я спасся, бросившись вплавь."
* [Ok]
-> END
=== res3 === 
Я только устроился на песке, когда приползли змеи. островок ими кишил. Я дожидался помощи по пояс в воде. Хорошо, что меня заметили другие люди на SUP и спасли
~TextForLog = "Волей судьбы, я оказался на необитаемом островке недалеко от материка. Я устроился хорошо отдохнуть и позагорать, но приползли змеи. Хорошо, что меня спасли."
* [Ok]
-> END
=== res4 === 
Я орал что есть мочи, но меня никто не слышал, кроме змей, которыми кишилд остров. Они приползли на мой зов и я дожидался помощи по пояс в воде. Хорошо, что меня заметили другие люди на SUP и спасли
~TextForLog = "Волей судьбы, я оказался на необитаемом островке недалеко от материка. Остров оказался населен множеством змей. Мои дикие крики привлекли людей и меня спасли."
* [Ok]
-> END