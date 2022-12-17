VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 30
VAR Character0MaxAgeSc = 50
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 50
VAR NPC1RelationshipSc = "Friend"
VAR NPC1GenderSc = "Opposite"

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC1SympathyCh = 0

At a party me and %FullName:NPC:1% are throwing, our friend %FullName:NPC:2% comes up and kisses me on the lips in front of everyone.
What should I do?
* [Push %FullName:NPC:2% away.]
    -> res1
* [Pull away from %FullName:NPC:2%]
    -> res2
* [Just let her do it.]
    -> res3

=== res1 === 
%FullName:NPC:2% is embarrassed and %FullName:NPC:1% gets mad at me for treating %Pron:2:2% that way.
~TextForLog = "I was just trying to stop %FullName:NPC:2% from kissing me, clearly %Pron:2:1% had a few too many drinks. I thought %FullName:NPC:1% would be mad if I just let %Pron:2:2% do it, so I don't know what the right thing to do was!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:2% keeps trying to kiss me and so %FullName:NPC:1% has to step in and stop %Pron:2:2%.
~TextForLog = "Well, I tried to pull away but %FullName:NPC:2% kept trying to kiss me. %Pron:2:1% definitely had too many drinks. Then, %FullName:NPC:1% had to step in and separate %FullName:NPC:2% from me and then they get into an argument. %FullName:NPC:1% is happy with me for how I tried to handle it, but mad at %FullName:NPC:2%."
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
Letting %FullName:NPC:2% kiss me encourages %Pron:2:2% to keep going and %FullName:NPC:1% is furious with me.
~TextForLog = "I could tell %FullName:NPC:2% had too much to drink and I was trying to let %Pron:2:2% get it out of %Pron:2:2% system but then %FullName:NPC:1% thought I wanted to be kissing %Pron:2:2% and is furious with me. Also, now %FullName:NPC:2% thinks we have something going on or something. I don't know. What a disaster!"
~Character0HappinessCh = "%ValueRef:1:-%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC1SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
