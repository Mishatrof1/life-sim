VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "Школа"
VAR TextForLog = ""

VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я увидел, как 2 старшеклассника пытаются убить котенка. Что делать?
* [Кинуться на них с кулаками]
    -> res1
* [Посмотреть, что будет. Ведь интересно же]
    -> res2
* [Уйти, это же не мой котенок]
    -> res3
* [Громко позвать кого-нибудь из старших]
    -> res4

=== res1 === 
Котенок удрал, а мне здорово досталось, но это ничего, ведь я спас маленкую жизнь.
~ChangeHappiness = 10
~ChangeHealth = -5
~TextForLog = "2 старшеклассника пытались убить котенка. Я кинулся на них с кулаками и спас котенка. Хотя мне досталось, я горжусь своим поступком."
* [Ok]
-> END
=== res2 === 
Котенок укусил одного из живодеров за палец и удрал. Со злости, они  вдвоем набросились на меня и избили. За что?!
~ChangeHappiness = -5
~ChangeSmarts = -5
~TextForLog = "2 старшеклассника пытались убить котенка. Мне стало интересно, что будет. Котенок удрал, а живодеры выместили свою злость на мне."
* [Ok]
-> END
=== res3 === 
Надеюсь, с котенком ничего не случилось. Впрочем, я вскоре забыл об этом случае.
~ChangeHappiness = -3
~ChangeSmarts = 10
~TextForLog = "2 старшеклассника пытались убить котенка. Я не стал вмешиваться, ведь это не мой котенок."
* [Ok]
-> END
=== res4 === 
Никто не откликнулся, зато котенок сумел удрать. Теперь придется скрываться, так как живодеры будут охотиться за мной.
~ChangeHappiness = -2
~ChangeSmarts = -2
~TextForLog = "2 старшеклассника пытались убить котенка. Я позвал на помощь старших. Никто не откликнулся, зато котенок сумел сбежать. Я тоже и теперь я скрываюсь от этих живодеров."
* [Ok]
-> END