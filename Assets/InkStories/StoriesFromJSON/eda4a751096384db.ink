VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Female"
VAR NPC1RelationshipSc = "Friend"

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR NPC1RelationshipCh = 0

I have loads of homework and my mother asks me to go to the grocery store with her to help her shop.
What do I do?
* [Go with her anyway.]
    -> res1
* [Tell her I have homework and stay home to do my homework.]
    -> res2
* [Tell her I have homework but go hang out with my friend %FirstName:NPC:2%]
    -> res3
* [Tell her I want to hang out with my friend %FirstName:NPC:2%]
    -> res4

=== res1 === 
We go to the store and have a good time talking and shopping and I also find $50 in the parking lot!
~TextForLog = "My mother and I had a great time at the store together, talking and sharing stories, I even found $50! But I completely forgot about my homework and my grades were affected."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~Character0WealthCh = "%50%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My mother understands and I stay home and finish my homework. However, I forget to eat and faint.
~TextForLog = "My mother was happy I was being responsible and I managed to finish all of my homework and learned a ton! Forgot to eat though, fainted in the bathroom and hit my head!"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I play video games with %FirstName:NPC:2% at his place and when my mother comes home and I’m not there, she grounds me.
~TextForLog = "%FirstName:NPC:2% and I had a blast doing nothing but playing video games. Might be the last time I get out of the house in awhile since my mother grounded me for lying."
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My mother tells me if I stay home I have to do my homework. I stay home and do most of my homework but spend a lot of time eating snacks and watching TV.
~TextForLog = "My mother was mad and made me stay home and do homework. I did most of it but decided I needed to unwind with snacks and TV too. Not that I told her that, but it turned out pretty great!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
