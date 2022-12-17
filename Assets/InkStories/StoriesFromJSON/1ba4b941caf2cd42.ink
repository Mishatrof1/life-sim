VAR StoryTittle = ""
VAR StoryQuestion = "So what do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelativesSc = "Kid:AdoptedKid"
VAR NPC0MinAgeSc = 3
VAR NPC0MaxAgeSc = 16

VAR Character0HealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0

My kid wants a peanut butter and jelly sandwich for lunch but %Pron:1:1% has a peanut allergy.
So what do I do?
* [Make an almond butter and jelly sandwich]
    -> res1
* [Make a cashew butter and jelly sandwich]
    -> res2
* [Make %Pron:1:2% a salad]
    -> res3
* [Make %Pron:1:2% my famous pesto pasta]
    -> res4

=== res1 === 
My kid loves the substitution and this is %Pron:1:3% new favorite. It turns out this was a healthier alternative for us too!
~TextForLog = "Alright, good to know %Pron:1:1% likes almond butter a lot! This may be %Pron:1:3% new lunch from now on. And it’s pretty healthy so we both got a positive there!"
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
It turns out my kid also has a cashew allergy so I have to rush %Pron:1:2% to the hospital and in driving to the hospital we get in an accident and I break my arm.
~TextForLog = "I didn’t realize my kid also had a cashew allergy and then I had to rush %Pron:1:2% to the hospital and in all the chaos I ran a red light and hit a car and broke my arm. We got an ambulance to the hospital for both of us. Oh, this has been terrible!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:2:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%Pron:1:1% gets angry because %Pron:1:1% doesn’t want a salad and refuses to eat it, so I eat his salad as well.
~TextForLog = "My kid got mad because %Pron:1:1% didn’t feel like a salad and wouldn’t eat. Hey, I’m just trying to make something healthy for us and %Pron:1:1% is telling me I’m no fun."
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
While we make this we research about Italian cooking and learn a lot. The food is delicious and we have a great time, but it is heavy!
~TextForLog = "We had a great time making the dish and researching about it and about Italian cooking and it was so delicious. But it’s so heavy, neither of us can even move!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
