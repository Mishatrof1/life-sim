VAR StoryTittle = ""
VAR StoryQuestion = "This is the first time I have ever tried riding without stabilizers."
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 3
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Parent"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

%FirstNameNPC1% is taking me out to learn to ride my new bike!
This is the first time I have ever tried riding without stabilizers.
* [Do everything you're told. You trust %FirstNameNPC1%!]
    -> res1
* [Do what you're told, unless it seems too scary. ]
    -> res2
* [Do it your own way!]
    -> res3

=== res1 === 
It turns out that %FirstNameNPC1% has a lot of faith in your abilities. You fall over a few times, and graze your knee, but by the end, you can ride your bike!
~TextForLog = "I learned to ride my bike today! I did everything I was told, fell off a few times, but hey! Now I can do it!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FirstNameNPC1% did get a little frustrated with me at times when I insisted that they hold the bike steady for a little. I suppose it did take longer. But... I can now ride my new bike!
~TextForLog = "I learnt to ride my bike today! Sure, it took me a while, and I was nervous, but who isn't when first getting on a two wheeled deathtrap?"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FirstNameNPC1% was way too bossy, and I would've hurt myself if I'd done what they told me. Instead, I tried teaching myself how to ride my bike. I am closer, but can't quite ride yet. 
~TextForLog = "I guess I irritated %FirstNameNPC1%... but they were making me way too nervous! Instead, I tried to learn to ride my bike by myself. I'm getting better, but I'm not quite there yet. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
