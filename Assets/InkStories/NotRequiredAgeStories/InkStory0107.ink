VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Мы переехали на новую квартиру. В тот же день к нам пришла кошка с намерением остаться жить.Я не собиралась заводить котов, как быть?
* [Оставить кошку]
    -> res1
* [Выгнать кошку]
    -> res2
* [Отправить кошку в приют]
    -> res3
* [Оставить кошку, чтобы пристроить ее у друзей]
    -> res4

=== res1 === 
Она оказалась беременной и вскоре родила девять котят. Проблема увеличилась в 10 раз
~TextForLog = "Мы переехали на новую квартиру. В тот же день к нам пришла кошка с намерением остаться жить. Я оставила кошку, и она вскоре принесла 9 котят. Пришлось их пристраивать."
* [Ok]
-> END
=== res2 === 
Кот - это проблема; нет кота - нет проблемы
~TextForLog = "Мы переехали на новую квартиру. В тот же день к нам пришла кошка с намерением остаться жить. Я ее выгнала, нам проблемы не нужны."
* [Ok]
-> END
=== res3 === 
Вскоре я узнала, что кошка родила 9 котят. теперь это проблема приюта. Хорошо что они умеют решать такие проблемы
~TextForLog = "Мы переехали на новую квартиру. В тот же день к нам пришла кошка с намерением остаться жить. Я отправила ее в приют для животных."
* [Ok]
-> END
=== res4 === 
Друзья согласились взять кошку, но она родила им 9 котят. Я своими действиями создала проблемы друзьям. Придется помогать им пристраивать котят
~TextForLog = "Мы переехали на новую квартиру. В тот же день к нам пришла кошка с намерением остаться жить. Я пристроила кошку у друзей, там она родила 9 котят. Мне было неудобно перед друзьями."
* [Ok]
-> END