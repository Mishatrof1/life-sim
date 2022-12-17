VAR StoryTittle = ""
VAR StoryQuestion = "What should I wear, shoes or sandals?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0PopularityCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0

I'm going to the beach with some classmates.
What should I wear, shoes or sandals?
* [Sandals]
    -> res1
* [Shoes]
    -> res2

=== res1 === 
As I'm walking on the beach my sandals break and I step on a shell and cut my foot.
~TextForLog = "I was so mad, I couldn't believe it! I guess my sandals were pretty old and they just completely broke, After I cut my foot I had to hobble off the beach and all my classmates were talking about how tough I was. I wanted to cry but there were so many people around, I just held it in."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Everyone makes fun of me for wearing shoes but when we play frisbee I am zooming all around on the beach.
~TextForLog = "Everyone is making fun of me for wearing shoes to the beach. Whatever, when we played frisbee I was having a way easier time than everyone else. Running all around, grabbing the frisbee, tossing it around. I was able to move through the sand better than everyone else. Maybe shoes weren't so dumb after all, huh?"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
* [Ok]
-> END
