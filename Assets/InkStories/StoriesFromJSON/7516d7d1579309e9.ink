VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR NPC0RelativesSc = "Sibling:StepSibling"
VAR NPC0GenderSc = "Female"
VAR NPC1RelativesSc = "Parent:StepParent"
VAR NPC1GenderSc = "Female"
VAR NPC2RelativesSc = "Parent:StepParent"
VAR NPC2GenderSc = "Male"

VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC2RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0

My sister sneaks out of the house and sneaks back in and needs me to distract my parents so she can return to her room unnoticed.
What do I do?
* [Tell her I’m not going to help her]
    -> res1
* [I will try to distract parents by asking a question about homework]
    -> res2
* [I will try to distract parents by telling them a funny joke I heard]
    -> res3

=== res1 === 
My sister tries to sneak in but my parents catch her and she gets mad at me but my parents are happy I didn’t cover for her.
~TextForLog = "My sister gets annoyed with me for not covering for her but I didn’t want to get in trouble too! My parents were happy with me, but it’s upsetting my sister got so mad at me. I didn’t tell her to sneak out in the first place!"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC2RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My parents tell me to ask my sister since she knows more about this subject at which point they find out she snuck out and ground us both.
~TextForLog = "Our parents get mad at us and ground us both since I was trying to cover for my sister and it failed miserably! But my sister and I bond and she appreciates me trying."
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
~NPC2RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
The distraction works! My sister gets back into her room unnoticed and she is so grateful she even gives me some cash!
~TextForLog = "My funny joke served as a great distraction and my sister avoided getting in trouble! And the cash she gave me was a nice touch... hm, maybe I have stumbled across a new part-time job."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%10%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
