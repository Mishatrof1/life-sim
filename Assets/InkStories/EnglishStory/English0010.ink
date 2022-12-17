VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Some high schoolers were secretly smoking in the toilet. They offered me a drag. What should I do?
* [Agree to smoke with them]
    -> res1
* [Refuse under the excuse that I only smoke expensive cigarettes]
    -> res2
* [Report them to the teacher]
    -> res3
* [Refuse, cuz I know that smoking is very bad for my health]
    -> res4

=== res1 === 
I had a bad cough and threw up. Everybody's laughing at me now
~TextForLog = "Some high schoolers were secretly smoking in the toilet. They offered me a drag. I accepted but got sick and threw up. Everybody's laughing at me now."
* [Ok]
-> END
=== res2 === 
I will have to somehow prove my words now. Luckily, Dad smokes expensive cigarettes
~TextForLog = "Some high schoolers were secretly smoking in the toilet. They offered me a drag. I refused under the excuse that I only smoke expensive cigarettes."
* [Ok]
-> END
=== res3 === 
The smokers got detention. And I discovered a dead rat in my school bag
~TextForLog = "Some high schoolers were secretly smoking in the toilet. They offered me a drag. But I refused and told the teacher on them. As a revenge, they put a dead rat into my school bag."
* [Ok]
-> END
=== res4 === 
These morons were glad to have more cigarettes for themselves
~TextForLog = "Some high schoolers were secretly smoking in the toilet. They offered me a drag, but I refused cuz I know it's very unhealthy."
* [Ok]
-> END