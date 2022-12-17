VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool"
VAR Character0MinAgeSc = 5
VAR Character0MaxAgeSc = 4
VAR Character0GenderSc = "Female"
VAR NPC0RelationshipSc = "Friend"
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0AppearanceCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

It's a 'wear what you like day' and %FirstName:NPC:1% is wearing exactly the same shoes as me!
What should I do?
* [Say nothing - they're just shoes, aren't they?]
    -> res1
* [Politely ask %FirstName:NPC:1% why %Pron:1:1% chose those shoes to wear. ]
    -> res2
* [Accuse %FirstName:NPC:1% of copying you!]
    -> res3

=== res1 === 
%FirstName:NPC:1% mentions that we have the same shoes... and smiles. We both have great taste, don't we?
~TextForLog = "%FirstName:NPC:1% and I wore the same shoes to the 'wear what you like' day. Now we're bestest besties! "
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
%FirstName:NPC:1% says %Pron:1:1% likes them. Oh yeah... well duh! You feel a little bit stupid! But if %FirstName:NPC:1% likes them, it proves that they are lovely shoes!
~TextForLog = "I asked %FirstName:NPC:1% why %Pron:1:1% wore her shoes. The amazing revelation was that %Pron:1:1% likes them! Still, it means we are more alike than I thought!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FirstName:NPC:1% is really upset - %Pron:1:1% didn't copy you, and now she's upset! Why did you do that?
~TextForLog = "Me and my big mouth - I upset my friend by accusing her of copying me. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:1:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
