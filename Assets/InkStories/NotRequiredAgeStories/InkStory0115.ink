VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Работа"
VAR ProfessionalType = "Manager"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Начальник на работе тупее меня. Меня это бесит, но нужна продуманная линия поведения. Как быть?
* [Не лезть на рожон, выполнять все требования, в том числе и тупые]
    -> res1
* [Указывать начальнику на его ошибки и предлагать лучшие решения]
    -> res2
* [Уволиться, т.к. долго это терпеть невозможно]
    -> res3
* [Невзначай подкидывать начальнику дельные идеи под видом его собственных]
    -> res4

=== res1 === 
Моя покладистость привела к тому, что начальник сел мне на голову и сделал из меня раба своей тупости
~TextForLog = "Начальник на работе был тупее меня. Меня это здорово бесило. Я был покладист, в результате начальник сел мне на голову."
* [Ok]
-> END
=== res2 === 
Первое время у нас начальником возникали конфликты, но потом он догадался, что от меня есть польза и теперь ценит мои советы
~TextForLog = "Начальник на работе был тупее меня. Меня это здорово бесило. Я решил указывать на ошибки начальника и предлагать лучшие решения. Это помогло нам сработаться."
* [Ok]
-> END
=== res3 === 
Я долго искал другую работу и нашел с той же зарплатой и... с таким же тупым начальником
~TextForLog = "Начальник на работе был тупее меня. Меня это здорово бесило. Я уволился, потом долго искал новую работу. И нашел... с таким же тупым начальником."
* [Ok]
-> END
=== res4 === 
Благодаря мне, начальник пошел на повышение, а я занял его место... И он снова мой начальник
~TextForLog = "Начальник на работе был тупее меня. Меня это здорово бесило. Я стал подкидывать ему разумные решения и его повысили. Меня тоже и теперь он снова мой начальник."
* [Ok]
-> END