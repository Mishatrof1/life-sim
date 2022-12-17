VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC0SympathyCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0StrengthCh = 0

It’s my wife %FirstName:Npc:1%’s birthday.
What do I do?
* [Take her out to dinner and a movie]
    -> res1
* [Set up a DIY spa day at home with oils and creams I bought myself]
    -> res2
* [Take her to the new museum]
    -> res3
* [Take her out to paintball]
    -> res4

=== res1 === 
%FirstName:Npc:1% loved dinner and the movie was equally as great. But wow was that restaurant expensive!
~TextForLog = "This was a fantastic night for %FirstName:Npc:1% and I, the classic dinner and a movie choice was perfect! And sure it hit my wallet a bit hard, but it was worth it."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-100%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FirstName:Npc:1% loved the idea but then had an allergic reaction to some of the oils i bought and it ruined the whole day!
~TextForLog = "I honestly thought this was going to be a great gift idea but %FirstName:Npc:1% was furious when she had her allergic reaction to the oils, I guess this was a risky idea!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FirstName:Npc:1% didn’t mind the museum but she is annoyed I picked it for us to do on her birthday.
~TextForLog = "This ended up being quite a cheap choice and we learned a lot, but %FirstName:Npc:1% wasn’t too thrilled with the birthday gift and I think I may be in some trouble."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
At first, %FirstName:Npc:1% was annoyed but then we both ended up loving the experience and can’t wait to go back!
~TextForLog = "%FirstName:Npc:1% was skeptical at first but she ended up loving paintball and we’ve probably never been closer!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
