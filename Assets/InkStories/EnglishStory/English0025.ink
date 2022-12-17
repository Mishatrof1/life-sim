VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Our class went to the zoo. My classmate was naughty and opened the cage and let out the leopard. What should I do?
* [Scream]
    -> res1
* [Tell the teacher privately not to cause panic]
    -> res2
* [See what happens, it could be fun!]
    -> res3
* [Run away like hell]
    -> res4

=== res1 === 
Everybody got scared as hell, and the leopard most of all. They could barely catch it. The naughty classmate was expelled
~TextForLog = "We were in the zoo, when my classmate was naughty and let a leopard out of its cage. I screamed, and everybody got scared, the leopard most of all. They could barely catch it. The naughty classmate was expelled."
* [Ok]
-> END
=== res2 === 
We all had to urgently leave the zoo. That little nasty bully ruined our day! He deserves detention
~TextForLog = "We were in the zoo, when my classmate was naughty and let a leopard out of its cage. I quietly told the teacher about it, and our class left the zoo. That nasty little bully ruined our beautiful day! He deserves detention."
* [Ok]
-> END
=== res3 === 
It was real fun! Everyone's panicking, just me and my classmate laughing. Too bad they managed to catch the leopard so quickly...
~TextForLog = "We were in the zoo, when my classmate was naughty and let a leopard out of its cage. It was fun! Everyone's panicking, just me and my classmate laughing. Too bad they managed to catch the leopard so quickly..."
* [Ok]
-> END
=== res4 === 
The leopard chased after me and bit my heel! It doesn't hurt that bad, but I'm glad that my nasty classmate was expelled
~TextForLog = "We were in the zoo, when my classmate was naughty and let a leopard out of its cage. I ran, and the leopard chased me and bit my heel. It doesn't hurt that bad, but I'm glad that my nasty classmate was expelled."
* [Ok]
-> END