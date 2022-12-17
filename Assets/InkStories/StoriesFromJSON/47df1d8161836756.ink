VAR StoryTittle = ""
VAR StoryQuestion = "What should I say?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 13
VAR NPC0MaxAgeSc = 18
VAR NPC1OccupationSc = "Classmate"
VAR NPC1GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR NPC0SympathyCh = 0
VAR Character0IntelligenceCh = 0

I ask %FullName:NPC:1% if %Pron:1:1% wants to go out but %Pron:1:1% tells me %Pron:1:1% is going out with %FullName:NPC:1%.
What should I say?
* ["Yeah, I know. I meant all of us go out and do something."]
    -> res1
* ["Oh, sorry, I didn't know that."]
    -> res2
* ["Just kidding!"]
    -> res3

=== res1 === 
Now, I have plans with the two of them and I am the third wheel.
~TextForLog = "Both %FullName:NPC:1% and %FullName:NPC:2% have a great time with me and say we should do this more often but this was a nightmare for me! I wanted to go out on a date with %FullName:NPC:1% because I like %Pron:1:2%, I didn't want to see %Pron:1:2% up close spending time with %Pron:1:2% significant other!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% is forgiving but %FullName:NPC:2% gets mad at me for this.
~TextForLog = "%FullName:NPC:2% is mad at me even though I didn't know the two of them were dating! %Pron:2:1% even tells a bunch of other kids in school so that more people will think I'm a jerk. %FullName:NPC:1% didn't mind though and now I can tell %Pron:1:1% feels bad for me. Just what I need, right?"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0SympathyCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% laughs at this and no one else ever finds out about this.
~TextForLog = "%FullName:NPC:1% says I am really funny. Great, just what I want to be. The funny friend. At least no one else ever found out. This was quick thinking by me. But I'm still embarrassed about this myself."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
