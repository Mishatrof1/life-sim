VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я участвую в соревнованиях по поеданию бургеров. В финале мы остались вдвоем, но я уже не могу есть. Что делать?
* [Я не уступлю! Буду есть бургеры до победного конца]
    -> res1
* [Я все! Второе место - тоже хороший результат. К следующим соревнованиям подготовлюсь лучше!]
    -> res2
* [Попытаюсь мимикой и жестами вызвать у соперника рвотный рефлекс, чтобы его дисквалифицировали]
    -> res3
* [Съем еще один гамбургер и и остановлюсь, независимо от результата]
    -> res4

=== res1 === 
Мне стало плохо, меня увезли в больницу на промывание желудка. Но я победил!!!
~TextForLog = "Я участвовал в соревнованиях по поеданию бургеров. В финале мне стало плохо и меня увезли в больницу."
* [Ok]
-> END
=== res2 === 
После соревнований я основательно проблевался. Немного беспокоит печень, а в остальном все хорошо. Второе место!
~TextForLog = "Я участвовал в соревнованиях по поеданию бургеров. В финале я решил удовольствоваться вторым местом."
* [Ok]
-> END
=== res3 === 
Мне не удалось повлиять на соперника, зато самого меня вырвало. Дисквалификация!
~TextForLog = "Я участвовал в соревнованиях по поеданию бургеров. В финале я решил спровоцировать дисквалификацию соперника, в результате, дисквалифицировали меня самого."
* [Ok]
-> END
=== res4 === 
Я съел один бургер, а соперник полтора и выиграл. Я проблевался, немного беспокоит печень, а в остальном все хорошо. Второе место!
~TextForLog = "Я участвовалв соревнованиях по поеданию бургеров. В финале я съел меньше соперника и получил лишь второе место."
* [Ok]
-> END