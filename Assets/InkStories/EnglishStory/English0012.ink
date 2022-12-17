VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



A big dog scared me to death with its sudden barking from behind a fence. My actions?
* [Throw a rock at it]
    -> res1
* [Tease it]
    -> res2
* [Just ignore the dog]
    -> res3
* [Talk to it gently to try to calm it down]
    -> res4

=== res1 === 
The dog's hid away, but I'm sure it's thinking about how to get back at me
~TextForLog = "A big dog scared me to death with its sudden barking from behind a fence. I threw a stone at it."
* [Ok]
-> END
=== res2 === 
The dog jumped over the fence and started chasing me! I'm lucky I run fast
~TextForLog = "A big dog scared me to death with its sudden barking from behind a fence. I tried teasing it, but the dog ran after me. I hardly escaped from it."
* [Ok]
-> END
=== res3 === 
The dog left me alone, but next time it might be barking at me again
~TextForLog = "A big dog scared me to death with its sudden barking from behind a fence. I just ignored it."
* [Ok]
-> END
=== res4 === 
The dog kept barking, but also waving its tail at me. I think I will get some treat for it next time and try to win it over
~TextForLog = "A big dog scared me to death with its sudden barking from behind a fence. But I calmed it down with a nice talk. Next time, I will get a treat for the dog to try to win it over."
* [Ok]
-> END