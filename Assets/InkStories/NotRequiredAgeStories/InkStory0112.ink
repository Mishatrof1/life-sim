VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я внезапно узнал, что у меня на макушке образовалась плешь. Как реагировать?
* [Это закон природы, придется принять это изменение внешности]
    -> res1
* [Отлично! Пора менять имидж на более брутальный - побреюсь наголо]
    -> res2
* [Обращусь к врачу]
    -> res3
* [Начну носить парик]
    -> res4

=== res1 === 
Не скажу, что это легко, но воспринимать возрастные изменения нужно спокойно. Говорят, что рак возникает из клеток, отказывающихся стареть
~TextForLog = "У меня на макушке образовалась плешь. Я не стал переживать из-за этого, так как это закон природы."
* [Ok]
-> END
=== res2 === 
Новый я себе нравлюсь больше. Но, чувствую, что женщины иного мнения: их заинтересованные взгляды я ловлю на себе реже
~TextForLog = "У меня на макушке образовалась плешь. Я побрился наголо, чтобы поменять имидж на более брутальный."
* [Ok]
-> END
=== res3 === 
После дорогостоящего лечения, волосы назад не отросли, я лишь замедлил процесс их выпадения. Буду делать зачес назад
~TextForLog = "У меня на макушке образовалась плешь. Я обратился к врачу, это влетело мне в копеечку, зато удалось замедлить процесс выпадения волос."
* [Ok]
-> END
=== res4 === 
Парик - хорошая идея: у меня идеальная прическа, женщины на меня обращают внимание чаще. У них макияж, у меня - парик, условия равные
~TextForLog = "У меня на макушке образовалась плешь. Я начал носить парик."
* [Ok]
-> END