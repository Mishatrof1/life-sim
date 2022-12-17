VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I want to get me a nosejob, but my parents won't give me money. Where do I get some?
* [Find me a sugar daddy]
    -> res1
* [Do porn]
    -> res2
* [Get an extra job]
    -> res3
* [Raise money via crowdfunding platform]
    -> res4

=== res1 === 
It worked, I got a nose job and dumped him; in revenge, he broke my nose, so it was for nothing!
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
I got the money, but some people recognized me in the video. And I'm not eighteen yet! I'm in hell! 
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
I work like a dog, but, with my salary, I'll have the needed money no sooner than in a year
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
Luckily, people are generous and gullible! Just in a month, I collected the right sum
~TextForLog = ""
* [Ok]
-> END