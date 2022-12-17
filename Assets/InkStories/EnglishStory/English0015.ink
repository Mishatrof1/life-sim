VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I've found an expensive smartphone in the street. What do I do?
* [Discard the SIM card, clear the store and keep it]
    -> res1
* [Take it to the police]
    -> res2
* [Try to find the owner on my own]
    -> res3
* [Break it down]
    -> res4

=== res1 === 
No I have a great gadget, the guys are going to be so jealous!
~TextForLog = "I found an expensive smartphone in the street and decided to keep it."
* [Ok]
-> END
=== res2 === 
The phone turned out to belong to a drug dealer. The police tracked his contacts and hit the whole network. And I got a reward
~TextForLog = "I found an expensive smartphone in the street and took it to the police. It turned out a drug dealer's phone. The police tracked his contacts and hit the whole network. I got a reward."
* [Ok]
-> END
=== res3 === 
The phone turned out to belong to a drug dealer. They tried to get me involved in drug trafficking, but I ran away
~TextForLog = "I found an expensive smartphone in the street and wanted to return it to its owner. It turned out a drug dealer's phone. They tried to involve me in drug trafficking, but I ran away."
* [Ok]
-> END
=== res4 === 
The phone turned out to belong to a drug dealer. Good thing nobody saw me break it
~TextForLog = "I found an expensive smartphone in the street and decided to break it down. It turned out a drug dealer's phone. Good thing nobody saw me break it."
* [Ok]
-> END