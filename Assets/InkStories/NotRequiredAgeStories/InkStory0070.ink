VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я получила небольшое наследство от дальних родственников, как им рапорядиться?
* [Поделиться со всеми членами нашей дружной семьи]
    -> res1
* [Оставить себе]
    -> res2
* [Отдать в волонтерскую организацию]
    -> res3
* [Отдать в приют для животных]
    -> res4

=== res1 === 
У меня стало меньше денег, зато в мире стало больше добра и справедливости
~TextForLog = "Я получила небольшое наследство от дальних родственников и поделилась со всеми членами нашей дружной семьи."
* [Ok]
-> END
=== res2 === 
У каждого в жизни бывает шанс. Этот был мой, и я им воспользовалась
~TextForLog = "Я получила небольшое наследство от дальних родственников и решила оставить его себе."
* [Ok]
-> END
=== res3 === 
Я отдала эти деньги тем, кто в них больше нуждается. теперь моя карма чиста, а без тех денег я обойдусь
~TextForLog = "Я получила небольшое наследство от дальних родственников и отдала его в волонтерскую организацию."
* [Ok]
-> END
=== res4 === 
Сколько раз мое сердце сжималость, когда я встречала страдания животных. Тогда я ничем не могла помочь, а вот теперь представился случай и я его не упустила
~TextForLog = "Я получила небольшое наследство от дальних родственников и отдала его в приют для животных."
* [Ok]
-> END