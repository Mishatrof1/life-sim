VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

В лесу мы с приятелем наткнулись на медведя. Что делать?
* [Броситься в разные стороны, Спасется только один!]
    -> res1
* [Что есть мочи заорать на медведя, чтобы напугать его]
    -> res2
* [Вместе с приятелем взобраться на дерево]
    -> res3
* [Медленно пятиться, не глядя медведю в глаза]
    -> res4

=== res1 === 
Медведь погнался за приятелем и задрал его на смерть. Мне повезло, я остался цел
~TextForLog = "В лесу мы с приятелем наткнулись на медведя. Мы бросились врассыпную. Медведь выбрал приятеля, а я выжил."
* [Ok]
-> END
=== res2 === 
Медведь яростно бросился на нас. Приятеля задрал на смерть, а меня сильно ранил. Я долго лечился
~TextForLog = "В лесу мы с приятелем наткнулись на медведя. Мы начали орать на медведя, он бросился на нас - приятеля убил, а меня ранил."
* [Ok]
-> END
=== res3 === 
Мы сделали это быстро, а медведь был слишком тяжел и не полез за нами. Побродил вокруг дерева и ушел
~TextForLog = "В лесу мы с приятелем наткнулись на медведя. Мы взобрались на дерево. Медведь не полез за нами, т.к. был слишком тяжелым."
* [Ok]
-> END
=== res4 === 
К сожалению, приятелю не хватило хладнокровия, он поддался панике и побежал. Медведь убил его, а я выжил
~TextForLog = "В лесу мы с приятелем наткнулись на медведя. Я медленно стал пятиться, а приятель бросился бежать. Медведь бросился за ним и убил, а меня не тронул."
* [Ok]
-> END