VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я разбила садик у себя на заднем дворе, а соседская собака повадилась там какать и писять. Как быть?
* [Высказать соседу недовольство и потребовать, чтобы держал собаку подальше от моего сада]
    -> res1
* [Вежливо и смиренно попросить соседа следить за собакой]
    -> res2
* [Собрать собачьи экскременты и сунуть соседу в почтовый ящик. Я сунула собачьи экскремены соседу в почтовый ящик]
    -> res3
* [Ничего не делать, собачьи экскременты и селитра из мочи - отличные удобрения]
    -> res4

=== res1 === 
Сосед ответил мне в грубой форме, а его собака меня облаяла. Однако в моем саду этот пес больше не появлялся
~TextForLog = "Я разбила садик у себя на заднем дворе, а соседская собака повадилась там какать и писять. Я поругалась с соседом и это навсегда отвадило его пса от моего сада."
* [Ok]
-> END
=== res2 === 
Сосед извинился и пообещал убедить свою собаку не ходить в мой сад. Судя по тому, что на следующий день его собака оказалась в моем саду, сосед плохо умеет убеждать собак
~TextForLog = "Я разбила садик у себя на заднем дворе, а соседская собака повадилась там какать и писять. Я вежливо попросила соседа урезонить своего пса, но он не сумел этого сделать и пес продолжил посещать мой сад."
* [Ok]
-> END
=== res3 === 
В отместку сосед натравил на меня полицию, но я все отрицала и они от меня отстали
~TextForLog = "Я разбила садик у себя на заднем дворе, а соседская собака повадилась там какать и писять. Я сунула собачьи экскремены соседу в почтовый ящик. Ибо нечего!"
* [Ok]
-> END
=== res4 === 
Мой сад  - райское местечко, не мудрено, что милому соседскому песику там нравится гулять
~TextForLog = "Я разбила садик у себя на заднем дворе, а соседская собака повадилась там какать и писять. Я совсем не против посещений милого песика, ведь он удобряет мой сад."
* [Ok]
-> END