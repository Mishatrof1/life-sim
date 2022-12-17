VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I accidentally saw our neighbor put money into his secret cache. I keep thinking about it, what should I do?
* [Forget it, I don't want to get involved with any criminal]
    -> res1
* [Prepare a good plan and rob him]
    -> res2
* [I know a couple of outlaws to fix it with. For a tip, I can get my share]
    -> res3
* [Tell the neighbor to be careful with his money]
    -> res4

=== res1 === 
I have better things to do with my life; and money, I can earn myself
~TextForLog = "I accidentally saw our neighbor put money into his secret cache. But I made myself forget about it."
* [Ok]
-> END
=== res2 === 
I took the money and she didn't work and she did well the police have questioned everyone around including me but in vain
~TextForLog = "I accidentally saw our neighbor put money into his secret cache. I prepared a plan of robbery and took the money."
* [Ok]
-> END
=== res3 === 
I took the money and hid it well. The police have questioned everyone, including me, but they had nothing
~TextForLog = "I accidentally saw our neighbor put money into his secret cache. I tipped off a couple of outlaws about it and had my share. I'm also in the gang now."
* [Ok]
-> END
=== res4 === 
Our neighbor thanked me and gave me twenty bucks. What a cheapskate!
~TextForLog = "I accidentally saw our neighbor put money into his secret cache. I told my neighbor to be careful with his money, and he thanked me and gave me twenty bucks. What a cheapskate!"
* [Ok]
-> END