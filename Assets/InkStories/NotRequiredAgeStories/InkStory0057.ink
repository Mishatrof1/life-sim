VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Семья"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

В кафе мне подали картошку фри с дохлым тараканом. Как реагировать?
* [Начать громко и нервно возмущаться]
    -> res1
* [Вынуть таракана и съесть картошку]
    -> res2
* [Вернуть блюдо официанту, попросить другое]
    -> res3
* [Вырвать прямо в блюдо с картошкой]
    -> res4

=== res1 === 
Вас попросили покинуть заведение, разрешив не платить
~TextForLog = "В кафе мне подали картошку фри с дохлым тараканом. Я громко возсмутилась и ушла, не заплатив."
* [Ok]
-> END
=== res2 === 
Никто ничего не заметил, ну и ладно
~TextForLog = "В кафе мне подали картошку фри с дохлым тараканом. Таракана я выбросила, а картошку съела с аппетитом."
* [Ok]
-> END
=== res3 === 
Вам с извинениями принесли другую порцию картошки и вы продолжили трапезу
~TextForLog = "В кафе мне подали картошку фри с дохлым тараканом. Я вернула блюдо официанту и мне с извинениями принесли другое."
* [Ok]
-> END
=== res4 === 
Все вокруг стали возмущаться и вы вынуждены были покинуть кафе
~TextForLog = "В кафе мне подали картошку фри с дохлым тараканом. Меня вырвало прямо в картошку. Пришлось срочно покинуть заведение."
* [Ok]
-> END