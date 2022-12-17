VAR StoryTittle = ""
VAR StoryQuestion = "Would it be letting her down to quit and take up soccer instead?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

My mom had dreams of being a gymnast and is really happy that I'm so good at it. But I don't really want to go anymore. I'm more interested in soccer.
Would it be letting her down to quit and take up soccer instead?
* [Carry on going to gym. I usually like it when I get there. ]
    -> res1
* [Give gym a break. Soccer looks really cool.]
    -> res2
* [Pretend I'm injured, and slowly get Mom used to the idea of soccer. ]
    -> res3
* [Try and do both gym and soccer!]
    -> res4

=== res1 === 
I decided to keep going to gym and it did get better. It's fun being so good at something. Plus, my mom is always so proud. I'll stick with it for now. 
~TextForLog = "I stuck with gym and now I'm enjoying it again. I love making my mom proud too. "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I told my mom that I wanted to give gym a break and take up soccer. She looked a little sad, but then smiled. Football is great and I think my mom is proof I want to try new things. 
~TextForLog = "I decided to just give gym a break and play soccer instead. I doubt I'll go back!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
It didn't work. I kept forgetting which shoulder I'd 'hurt' and Mom saw right through the trick. Now she forces me to go to gym!
~TextForLog = "My mom knows what's good for me, I guess. She also smells a lie from a hundred yards. I guess I'm not quitting gym anytime soon. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
I love soccer and gym got better after a while too. Sometimes I just get a little tired. Ok, a lot tired. 
~TextForLog = "I'm either going to be a gymnast, a soccer player or a zombie! I didn't quite gym but I did take up soccer! Bring it on... But, so tired right now! "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:1:+%"
~Character0StrengthCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
