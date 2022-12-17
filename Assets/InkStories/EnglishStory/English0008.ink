VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I saw two high-schoolers trying to kill a kitten. What do I do?
* [Attack them]
    -> res1
* [Keep watching, it might get interesting!]
    -> res2
* [Just leave. After all, it's not my kitten]
    -> res3
* [Shout to bring some adults for help]
    -> res4

=== res1 === 
The kitten escaped! I got beaten, but that's all right, cuz I saved a little life
~TextForLog = "Two high-school boys were trying to kill a kitten. I attacked them and saved the kitten. And, even though they gave me a good beating, I'm proud of myself."
* [Ok]
-> END
=== res2 === 
The kitten bit one of the bullies' finger and ran away. They got mad and took it all on me. Why?!
~TextForLog = "Two high-school boys were trying to kill a kitten. I decided to see what happens. The kitten escaped, and the guys got angry and took it all on me."
* [Ok]
-> END
=== res3 === 
I hope the kitten's going to be alright. Anyway, I soon forgot about it
~TextForLog = "Two high-school boys were trying to kill a kitten. I decided not to interfere, for it wasn't my kitten after all."
* [Ok]
-> END
=== res4 === 
No one came round, but the kitten managed to escape. Now I have to look out for those bullies cuz they are going to follow me everywhere
~TextForLog = "Two high-school boys were trying to kill a kitten. I shouted to bring someone's attention. No one came up, but the kitten managed to escape. Now I have to hide from these bullies, too."
* [Ok]
-> END