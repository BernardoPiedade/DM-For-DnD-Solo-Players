﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_SoloPlayers
{
    public partial class RE_Forest : Form
    {
        public RE_Forest()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            show_m();
        }

        public void show_m()
        {
            List<string> answer = new List<string>();


            //Start List Content

            answer.Add("A great elk is seen watching the party from a distance. It almost looks as if the elk is wearing a crown made of twigs and vines.");
            answer.Add("A party member trips on a hidden rock. As they are falling, they feel as though they are being ‘caught’ before hitting the ground. A nearby ent uses it’s vines to catch the player before they hurt themselves.");
            answer.Add("A gnome tinkerer rides past the party going the opposite direction. He appears every three hours of travel until the party buys something.");
            answer.Add("A pair of wood elves are seen setting traps for poachers. If the party proves to be friends of the forest, the elves will take them to an extradimensional nature preserve full of extinct and oversized creatures.");
            answer.Add("A water elemental and an earth elemental are seen attempting to make plant babies.");
            answer.Add("3d6 elvish, gnomish, human, and children are playing a game of tag in the forest.");
            answer.Add("It is black as night underneath one tall tree, everywhere else the light comes through as normal.");
            answer.Add("A camouflaged giant trapdoor spider nest, 15 feet in diameter.");
            answer.Add("You past through a barren section of the forest that was damaged about a decade ago by a forest fire. In the middle of this relative desolation, you find a circle of trees that seems untouched by fire that destroyed the surroundings.");
            answer.Add("A group of goblins arguing over directions.");
            answer.Add("An awakened tree stands motionless until in striking range of the party! Who or what brought this tree to life?");
            answer.Add("A group of tribal warriors who jump the party in the forest. All of the warriors are nude, and wear body paint to mark how many kills they have.");
            answer.Add("In the high tree tops of the forest an unknown enemy waits to attack the weakest creature that wonders by. The Panther is black with white spots on its head, and will attack anything that moves.");
            answer.Add("A satyr has welcomed the group to a festival. If the invitation is accepted, the group gets to drink honey flavored ale and eat campfire cooked fish and fruits with the satyr and his 2 friends.");
            answer.Add("A faerie dragon is being attacked by a lemure. If helped, the dragon will repay the party with 15 gp each and a little container of honey.");
            answer.Add("The party finds a scared injured owlbear cub hiding under a large bush. The party can choose to leave it, or keep it and nurse it back to health.");
            answer.Add("A massive mastiff comes bounding by, shortly followed by an exhausted warrior holding a leash attached to a broken collar.");
            answer.Add("The party finds a well labeled “wishing well: insert money for fortune.” Every (PC level) gp thrown in adds grants the “lucky” feat for one hour, or until used.");
            answer.Add("A NE goblin is trapped in a giant spider’s web. If the players approach, the goblin untangles himself and attacks as a Druid alongside the spiders.");
            answer.Add("A door standing upright in thick bushes completely ignored by nature. If a player opens the door a small cabin interior is found and the faint aroma of cooked meats float out.");
            answer.Add("A party member swears they can hear the crows mumble actual words from time to time. If the party quiets down enough the party member will hear that the words are cardinal directions. If heeded, the crows will continue to guide the party to a giant crow sleeping on a nest of treasure.");
            answer.Add("A party member trips and falls against a tree, but instead of making a wooden thunk a hollow reverberation is heard. Further inspection will lead the party to find tree is hollow with a small metal box inside, containing items that they had lost.");
            answer.Add("The party comes across a thick tree, filled with 2d6 big wasp hives. If they stay around for too long, they are attacked by the same number of wasp swarms.");
            answer.Add("The party comes across a river, filled with piranhas. There is no bridge, though.");
            answer.Add("A lightning storm begins, and several trees are struck with lightning. However, some of them don’t burn, instead they just become electrified, and creatures around them randomly receive small discharges, taking 1d6 electric damage per turn. The party is then attacked by monsters.");
            answer.Add("A mammoth is heard, trumpeting, running and toppling trees nearby. It will attack the party on sight, if they fail to hide. If they choose to investigate, they will discover hunters killed the rest of the herd to take the ivory.");
            answer.Add("The party comes across a random inn. If they choose to enter, it will catch on fire, right in the middle of whatever they were doing in there.");
            answer.Add("A pale female Aasimar and 7 male Dwarven miners are seen heading home. They won’t stop singing and she swears it’s platonic.");
            answer.Add("An emotionally disheveled girl in a red hooded cape offers to sell you a dire wolf pelt for 20 GP or the deed to her deceased grandmother’s cabin for 500 GP.");
            answer.Add("You encounter a logging camp with a storm giant, his comically large axe, and his blue dire ox.");
            answer.Add("A pack of goblins on wolf-back runs by the party too scared to stop, followed by two bears and two druids in hot pursuit.");
            answer.Add("A druid pops out of a tree yelling ‘Anyone wanna buy some sage or mushrooms?!’ It’s not sage, the mushrooms are legit though.");
            answer.Add("The party finds a wagon with a busted wheel. The former owner left his horse, Ed, attached to the cart to die. Ed speaks Common. There’s a barrel of water, four bottles of wine, two carpets, pots, pans, and hay with carrots for Ed in the back. The wheel is able to be temporarily fixed with a belt or rope.");
            answer.Add("A flock of blue green birds that attempt to lead the party to a forgotten shrine to a minor nature spirit.");
            answer.Add("A large and beefy stag appears, full of delicious venison just waiting to be claimed by your party. Once the creature is downed and retrieved, its tough hide is ready to be removed. One small incision reveals something truly horrific, however. Its body has been stuffed with the eggs of a vile creature! Suddenly, squishy cracking sounds can be heard, and the carcass begins to slowly writhe…");
            answer.Add("A fox and mastiff run in front of you. The party can tell they’re best friends.");
            answer.Add("You find a male human sleeping and covered in cobwebs. He’s been there for a while. Apparently he lost a drinking contest to the feyfolk 25 years ago.");
            answer.Add("You see a human trapped in a bear trap. Upon release she shifts into bear form and runs away.");
            answer.Add("A herd of wild horses and centaurs are seen running through a glade.");
            answer.Add("A male dwarf and his cougar step out of the bushes in front of the party. She says ‘Hi.’ to the party.");
            answer.Add("An archer, cleric, rouge, and large barbarian attempt to rob the party. It Sherwood be nice if you got along.");
            answer.Add("The party sees a house made of candy just off the path. You hear the hag inside lamenting building it so deep in the forest.");
            answer.Add("A group of fairies are seen tormenting a pair of orphaned wolf pups. The party can scare the fairies off easily enough but the pups need someone to look after them.");
            answer.Add("The party encounters a two story crack 3 meters up in a tree…filled to the brim with an abnormally large bee hive full of honey.");
            answer.Add("The party comes across an all male village of blue sprites. The one with the red hat and beard appears to be the leader. They live in hallowed out mushrooms.");
            answer.Add("You see a paralyzed boy being drawn on a sled by a half giant. He’s accompanied by three other children. One is his little brother and they’re heading North after their family was slaughtered. No spoilers.");
            answer.Add("You meet a human female archer with red hair. She calls you fools and keeps saying, ‘When I find that bastard…I’m gonna kill ’em!’");
            answer.Add("You find an old hermit hut with the dead man still in his bed. His mastiff, Mēko, needs a new master.");
            answer.Add("A lost warband of wood elves offer you trade for supplies and rations.");
            answer.Add("The god Solonor Thelandira appears and gives gifts to any elves or half elves in the party.");
            answer.Add("The party approaches a camp of 5 dead kobolds. They seem to have been reaching for their weapons. Strangely, there are no cuts or bruises. If the the party stays there for more than an hour, 1D4 cloakers descend from the trees and assault them. If they stay there overnight, they will be woken up by an attack from 1D8 cloakers as well as a swarm of rats which get killed by the cloakers.");
            answer.Add("An elven child runs to the party, crying. A group of 1D6 names and 1D4 cultists approach the party. One of the cult members demands that the party hands back their sacrifice to their new fiend acquaintances.");
            answer.Add("A very friendly gnome running a little shop greets the group. He says he used an awaken spell on the flowers he sells. He’s selling them in bunches for 25 gp each. He’s also selling fireflies in jars for 15 gp each as well as giant fire beetles in jars for 20 gp each.");
            answer.Add("A werebear wearing a pair of jeans and a park ranger hat with “SMOGGY” written on it approaches the party and gives them a 1D10 hour lecture on how you should be careful using fire or fire related spells in forest areas. Once finished, he tells the party “Only YOU can prevent a forest fire.” and proceeds to ride off on the back of an owlbear.");
            answer.Add("A very wide tall tree, with a hollow opening 60+ feet up. Should a player look in, they see nothing down the hole. A few moments later they are pushed into the hollow by an unseen enemy. The tree is infested with phase spiders.");
            answer.Add("A tribe of Firbolg are seen disappearing into a tree. They look sad and hurried to leave.");
            answer.Add("You see a dryad summon three 30 ft. spikey, coiled wooden tendrils and just pummel a mimic to death.");
            answer.Add("You catch a gnome in the mouth of a bear. He screams, ‘This isn’t what it looks like!’ As they both run into the bushes.");
            answer.Add("A halfling and thirteen dwarves are being chased by giant spiders. If you help them they may give you something precious to them.");
            answer.Add("You see a trail of ravens eating bread crumbs. Off in the distance are an orphaned brother and sister. They beg you to murder their shity stepmother since this is the third time she’s made their father do this.");
            answer.Add("Entering a marshy part of the woods you find a dire rat’s nest. Aside from the rodents of unusual size the marsh gases erupt randomly doing 1d4 fire damage.");
            answer.Add("While keeping watch, you notice a glimpse of something white flitting between the trees in the corner of your eye. You turn to look but it’s gone. Feeling the hairs on your arm stand up, you whirl around to see a sad, filthy woman wearing a torn white robe standing at the edge of your encampment. She opens her mouth hideously to scream, but only blood spills from her lips, staining her white clothes. In a flash she flies toward you with arms outstretched. A jolt runs through your body as your eyes snap open and you realise you had nodded off…");
            answer.Add("A ska band made up of humans and elves live up in a tree.");
            answer.Add("A human, dwarf, and elf prince are searching for a certain wizard.");
            answer.Add("A Warforged holding an ax has rusted near a felled tree. If only someone could find his oil can and free him up…");
            answer.Add("A herd of 500 reindeer and their nomadic half elven caretakers are driving them north. They can trade for furs, meats, reindeer mounts, and cold weather clothing.");
            answer.Add("You see an ent trapped between two boulders. Upon freeing him he grants you all 2 hours of Barkskin.");
            answer.Add("You come across a marriage ceremony between an elf and a human. It’s held in secret because of the hatred between their two families.");
            answer.Add("You find four halflings being grappled by the roots of an awakened tree. They have a precious reward if saved.");
            answer.Add("The party encounters 1d4 worg scouts. If not killed in 5 rounds then 1d4 goblins on worg-back ride in.");
            answer.Add("The party encounters three bears eating the corpse of a blond female. They revert to human form once they die and their recently ransacked cottage is nearby.");
            answer.Add("As the party is traveling through the forest, a shrieker sounds off. A thug jumps in front of the group, nothing but commoner clothes and a dagger. They are very easy to persuade, and even easier to intimidate.");
            answer.Add("The party comes across a small fenced garden, growing some carrots and potatoes. The smell of stew fills the air, and a gnome appears, and invites them to have a meal.");
            answer.Add("An incredibly large tortoise is bound in place by ropes apparently put in place by hunters, it looks at the party with sad but remarkably intelligent eyes.");
            answer.Add("You come across a dryad as it strides across the path between thickets. It turns to look at you. In it’s arms is a happily cooing half orc child.");
            answer.Add("A bear with three arms wanders around roaring, it freaks out at the sight of humanoids. If you can get closer you can see the third paw is bloody due to a large splinter.");
            answer.Add("The party encounters 1d4 druids that wild shape into wolves and run when startled.");
            answer.Add("A sprite throws a glittery dust bomb at the shortest member of the party and disappears. That night a female mountain lion nuzzles up to them and is very friendly. Too friendly…");
            answer.Add("In an old part of the woods four female Treants are being held captive by a trio of hags. If rescued they offer a primal medallion that allows a player to create 1 awakened shrub per day.");
            answer.Add("A group of Firbolgs are tending to an injured friend. The dead orc slavers must’ve thought there was just one.");
            answer.Add("Deep in the woods you find a sword lodged in a stone surrounded by thorny vines that drip poison.");
            answer.Add("The party stumbles upon a Treant nursery. They’re cute, but you have three minutes until their mothers arrive.");
            answer.Add("A small elemental starts a forest fire that quickly covers the forest.");
            answer.Add("A large owl and a large squirrel chase after a terrified goblin.");
            answer.Add("You meet an elvish veteran of the last war. He’s still in survival mode under orders and it’s up to the party to convince him to go home.");
            answer.Add("A traveling caravan of friendly Tabaxi has circled the wagons for the night. When you approach and sit near the fire twenty more Tabaxi come down from the trees to meet you. They are armed to the teeth, but friendly. Seems like a nice and safe place to sleep for the night.");
            answer.Add("You find a human ranger named John Ramco being chased by 1d4 Orcs. He has a giant knife and asks you to help him set an ambush.");
            answer.Add("You come to the house of a well known Goliath druid Jëorn that is notorious for shifting into a bear and killing entire packs of orcs. He offers you lodging for the night, milk, cheese, honey, and rental horses.");
            answer.Add("A tinker Gnome and her two Warforged friends have created a giant dragon construct made of wood. They plan on scaring off the local tribe of orc slavers with it.");
            answer.Add("You find 1d4 goats near a bridge over a stream. Troll encounter optional.");
            answer.Add("The party stops just in time to see an endangered herd of aurochs. All 30 to 40 appear to be moving to another glen to graze. Stay low and be quiet.");
            answer.Add("Four teenage humans and a dog that speaks common have a minotaur tied up. They remove the mask to reveal an old Dwarf just as the nearby city guards arrive to take him away.");
            answer.Add("You find a circle of earth Genasi petrified in worship of a giant, floating, glowing red crystal. Any interference causes the crystal to lash out at you with eldritch red bolts of fire and lightning laced shards. These would make great arrow heads…");

            //End list content

            //random to select answer from list
            Random rnd = new Random();

            int select = rnd.Next(0, answer.Count);

            textBox1.Text = (answer[select].ToString());
        }

        private void New_One_Click(object sender, EventArgs e)
        {
            show_m();
        }
    }
}
