VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я случайно увидел через окно, где наш сосед хранит деньги. Это мысль не дает мне покоя, как поступить?
* [Забыть. Не хватало мне еще вляпаться в криминал!]
    -> res1
* [Хорошо подготовится, и в его отсутствие влезть за деньгами ]
    -> res2
* [Я знаю парочку крутых парней. За наводку я наверняка получу свою долю]
    -> res3
* [Сказать соседу, чтобы лучше прятал деньги. Ведь не все такие честные, как я]
    -> res4

=== res1 === 
У меня прекрасная жизнь, незачем ее портить. А деньги я заработаю своим умом
~TextForLog = "Я случайно увидел через окно, где наш сосед хранит деньги. Это мысль не давала мне покоя, но я заставил себя забыть об увиденном."
* [Ok]
-> END
=== res2 === 
Деньги у меня и хорошо спрятаны. Полиция всех допрашивала, в том числе меня, но безрезультатно
~TextForLog = "Я случайно увидел через окно, где наш сосед хранит деньги. Это мысль не давала мне покоя. Я хорошо подготовился, влез и украл деньги."
* [Ok]
-> END
=== res3 === 
У нас все получилось. Я получил свою долю и теперь я член банды налетчиков. Это супер!
~TextForLog = "Я случайно увидел через окно, где наш сосед хранит деньги. Это мысль не давала мне покоя, поэтому я позвал парочку крутых ребят, которые вломились к соседу и похитили деньги. Я получил свою долю и стал членом банды."
* [Ok]
-> END
=== res4 === 
Сосед поблагодарил и от щедрот выдал мне двадцатку. Скряга!
~TextForLog = "Я случайно увидел через окно, где наш сосед хранит деньги. Это мысль не давала мне покоя. Я яказал соседу, чтобы лучше прятал деньги. Сосед поблагодарил и от щедрот выдал мне двадцатку. Скряга!"
* [Ok]
-> END