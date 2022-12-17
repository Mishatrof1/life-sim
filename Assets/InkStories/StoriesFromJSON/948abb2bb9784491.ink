VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelativesSc = "Kid:AdoptedKid"
VAR NPC0MinAgeSc = 4
VAR NPC0MaxAgeSc = 14

VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0

My kid wants to stay up late and watch a scary movie with me.
What do I do?
* [Tell %Pron:1:2% that %Pron:1:1% cannot]
    -> res1
* [Allow %Pron:1:2% to stay up and watch it]
    -> res2
* [Say %Pron:1:1% can stay up late but we will watch a comedy movie]
    -> res3
* [Say %Pron:1:1% can stay up late but we will watch an action movie]
    -> res4

=== res1 === 
%Pron:1:1% gets upset with me and storms off to %Pron:1:2% room but with the peace and quiet I can do some reading.
~TextForLog = "My kid was mad I didn’t let %Pron:1:2% stay up or watch the scary movie but I think it would’ve been too much for %Pron:1:2% but I had some nice alone time to read. But I feel badly my kid is so upset with me, I hope this doesn’t last too long."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%Pron:1:1% is happy that I let %Pron:1:2% stay up but %Pron:1:1% gets scared by the movie and is up all night having nightmares and I get no sleep.
~TextForLog = "My kid is happy I let %Pron:1:2% watch what %Pron:1:1% wanted but %Pron:1:1% has nightmares all night and I have to stay up with %Pron:1:2% and I slept virtually 0 minutes and feel like garbage!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%Pron:1:1% gets mad because %Pron:1:1% thinks I treat %Pron:1:2% like a baby and goes to bed early anyway. I watch the movie alone and it’s so dumb.
~TextForLog = "I thought my kid would be happy to stay up and watch the comedy movie but %Pron:1:1% thinks I picked that because I treat %Pron:1:2% like a baby. Turns out the movie was stupid and I’m dumber for having watched it now."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
%Pron:1:1% is happy I treat %Pron:1:2% like an adult and we have a fantastic time watching the movie together.
~TextForLog = "This was the perfect pick! The scary movie might have been too much for my kid but this action movie was still mature but not too scary for %Pron:1:2% and we had a blast watching it."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
