VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Меня по ошибке обвинили в преступлении, которого я не совершал.Все улики против меня. Как поступить?
* [Пойти на сделку: взять на себя вину в обмен на минимальный срок]
    -> res1
* [Бороться до конца, настаивая на своей невиновности]
    -> res2
* [Совершить побег с целью найти виновного]
    -> res3
* [Обратиться к в правозащитные организации]
    -> res4

=== res1 === 
Мне дали условный срок. Я так и не узнал, кто меня подставил
~TextForLog = "Меня по ошибке обвинили в преступлении, которого я не совершал. Я пошел на сделку: взял на себя вину в обмен на условный срок."
* [Ok]
-> END
=== res2 === 
Это оказалось бесполезно, я получил  срок, но вскоре вышел условно досрочно. Я так и не узнал, кто меня подставил
~TextForLog = "Меня по ошибке обвинили в преступлении, которого я не совершал. Я решил бороться до конца. Это оказалось бесполезно, я получил  срок, но вскоре вышел условно досрочно. Я так и не узнал, кто меня подставил."
* [Ok]
-> END
=== res3 === 
Я успел распутуть дело раньше, чем меня поймали. Меня подставил собственный племянник. Я приволок его в полицию. Теперь он в тюрьме, по заслугам
~TextForLog = "Меня по ошибке обвинили в преступлении, которого я не совершал. Я совершил побег и наше6л виновного. Это оказался мой собственный племянник."
* [Ok]
-> END
=== res4 === 
На моем деле несколько правозащитников сделали политическую карьеру. Но они помогли мене оправдаться. и я нашел виновного - это был мой собственный племянник. Теперь он в тюрьме
~TextForLog = "Меня по ошибке обвинили в преступлении, которого я не совершал. Я обратился в правозащитные организации. Они помогли мне оправдаться.Но они помогли мене оправдаться. И я нашел виновного - это был мой собственный племянник. Теперь он в тюрьме."
* [Ok]
-> END