VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я сильно поругался со своей девушкой, но не хочу с ней расставаться. Что делать?
* [Попрошу прощения и буду настойчиво искать способы примирения]
    -> res1
* [Буду ждать, когда она сделает первые шаги]
    -> res2
* [Спровоцирую ситуацию, которая поможет нам помириться без потери лица для обоих]
    -> res3
* [Буду настойчиво требовать от нее извинений, т.к. это она во всем виновата]
    -> res4

=== res1 === 
Мои усилия увенчались успехом, мы примирились
~TextForLog = "Я сильно поругался со своей девушкой, но не захотел с ней расставаться и поэтому приложил все усилия к примирению."
* [Ok]
-> END
=== res2 === 
Она их не сделала, а вскоре я увидел ее с другим парнем. Я идиот!
~TextForLog = "Я сильно поругался со своей девушкой, но не захотел с ней расставаться. Я проявил гордость и она нашла себе другого. Я идиот."
* [Ok]
-> END
=== res3 === 
Все вышло отлично, в подходящей ситуации она первая сделала шаги к примирению. Я горд своей находчивостью
~TextForLog = "Я сильно поругался со своей девушкой, но не захотел с ней расставаться. Я нашел компромисс, приемлемый для нас обоих и мы помирились."
* [Ok]
-> END
=== res4 === 
Она стала меня игнорировать и разорвала наши отношения
~TextForLog = "Я сильно поругался со своей девушкой, но не захотел с ней расставаться. Я наехал на нее и она разорвала наши отношения."
* [Ok]
-> END