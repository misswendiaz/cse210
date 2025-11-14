using System;
using System.Collections.Generic;

public class Passages
{
    // attributes (member variables)
    private Dictionary<Reference, string> _passages;
    private Random _random;

    // constructor
    public Passages()
    {
        // initializes the random generator
        _random = new Random();

        // question list
        _passages = new Dictionary<Reference, string>()
        {
            // Pearl of Great Price
            {new Reference("Moses", 1, 39), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."},
            {new Reference("Moses", 7, 18), "And the Lord called his people Zion, because they were of one heart and one mind, and dwelt in righteousness; and there was no poor among them."},
            {new Reference("Abraham", 3, 22, 23), "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones; \n\nAnd God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born."},

            // Old Testament
            { new Reference("Genesis", 1, 26, 27), "And God said, Let us make man in our image, after our likeness: and let them have dominion over the fish of the sea, and over the fowl of the air, and over the cattle, and over all the earth, and over every creeping thing that creepeth upon the earth.\n\nSo God created man in his own image, in the image of God created he him; male and female created he them." },
            {new Reference("Genesis", 39, 9), "There is none greater in this house than I; neither hath he kept back any thing from me but thee, because thou art his wife: how then can I do this great wickedness, and sin against God?"},
            {new Reference("Exodus", 20, 3, 17), "Thou shalt have no other gods before me.\n\nThou shalt not make unto thee any graven image, or any likeness of any thing that is in heaven above, or that is in the earth beneath, or that is in the water under the earth:\n\nThou shalt not bow down thyself to them, nor serve them: for I the Lord thy God am a jealous God, visiting the iniquity of the fathers upon the children unto the third and fourth generation of them that hate me;\n\nAnd shewing mercy unto thousands of them that love me, and keep my commandments.\n\nThou shalt not take the name of the Lord thy God in vain; for the Lord will not hold him guiltless that taketh his name in vain.\n\nRemember the sabbath day, to keep it holy.\n\nSix days shalt thou labour, and do all thy work:\n\nBut the seventh day is the sabbath of the Lord thy God: in it thou shalt not do any work, thou, nor thy son, nor thy daughter, thy manservant, nor thy maidservant, nor thy cattle, nor thy stranger that is within thy gates:\n\nFor in six days the Lord made heaven and earth, the sea, and all that in them is, and rested the seventh day: wherefore the Lord blessed the sabbath day, and hallowed it.\n\nHonour thy father and thy mother: that thy days may be long upon the land which the Lord thy God giveth thee.\n\nThou shalt not kill.\n\nThou shalt not commit adultery.\n\nThou shalt not steal.\n\nThou shalt not bear false witness against thy neighbour.\n\nThou shalt not covet thy neighbour’s house, thou shalt not covet thy neighbour’s wife, nor his manservant, nor his maidservant, nor his ox, nor his ass, nor any thing that is thy neighbour’s."},
            {new Reference("Exodus", 33, 11), "And the Lord spake unto Moses face to face, as a man speaketh unto his friend. And he turned again into the camp: but his servant Joshua, the son of Nun, a young man, departed not out of the tabernacle."},
            {new Reference("Leviticus", 19, 18), "Thou shalt not avenge, nor bear any grudge against the children of thy people, but thou shalt love thy neighbour as thyself: I am the Lord."},
            {new Reference("Deutoronomy", 7, 3, 4), "Neither shalt thou make marriages with them; thy daughter thou shalt not give unto his son, nor his daughter shalt thou take unto thy son.\n\nFor they will turn away thy son from following me, that they may serve other gods: so will the anger of the Lord be kindled against you, and destroy thee suddenly."},
            {new Reference("Joshua", 1,8), "This book of the law shall not depart out of thy mouth; but thou shalt meditate therein day and night, that thou mayest observe to do according to all that is written therein: for then thou shalt make thy way prosperous, and then thou shalt have good success."},
            {new Reference("Joshua", 24, 15), "And if it seem evil unto you to serve the Lord, choose you this day whom ye will serve; whether the gods which your fathers served that were on the other side of the flood, or the gods of the Amorites, in whose land ye dwell: but as for me and my house, we will serve the Lord."},
            {new Reference("Samuel", 16, 7), "But the Lord said unto Samuel, Look not on his countenance, or on the height of his stature; because I have refused him: for the Lord seeth not as man seeth; for man looketh on the outward appearance, but the Lord looketh on the heart."},
            {new Reference("Job", 19, 25, 26), "For I know that my redeemer liveth, and that he shall stand at the latter day upon the earth:\n\nAnd though after my skin worms destroy this body, yet in my flesh shall I see God:"},
            {new Reference("Psalm", 24, 3, 4), "Who shall ascend into the hill of the Lord? or who shall stand in his holy place?\n\nHe that hath clean hands, and a pure heart; who hath not lifted up his soul unto vanity, nor sworn deceitfully."},
            {new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding.\n\nIn all thy ways acknowledge him, and he shall direct thy paths."},
            {new Reference("Isaiah", 1, 18), "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."},
            {new Reference("Isaiah", 29, 13, 14), "Wherefore the Lord said, Forasmuch as this people draw near me with their mouth, and with their lips do honour me, but have removed their heart far from me, and their fear toward me is taught by the precept of men:\n\nTherefore, behold, I will proceed to do a marvellous work among this people, even a marvellous work and a wonder: for the wisdom of their wise men shall perish, and the understanding of their prudent men shall be hid."},
            {new Reference("Isaiah", 53, 3, 5), "He is despised and rejected of men; a man of sorrows, and acquainted with grief: and we hid as it were our faces from him; he was despised, and we esteemed him not.\n\nSurely he hath borne our griefs, and carried our sorrows: yet we did esteem him stricken, smitten of God, and afflicted.\n\nBut he was wounded for our transgressions, he was bruised for our iniquities: the chastisement of our peace was upon him; and with his stripes we are healed."},
            {new Reference("Isaiah", 55, 8, 9), "For my thoughts are not your thoughts, neither are your ways my ways, saith the Lord.\n\nFor as the heavens are higher than the earth, so are my ways higher than your ways, and my thoughts than your thoughts."},
            {new Reference("Jeremiah", 16, 16), "Behold, I will send for many fishers, saith the Lord, and they shall fish them; and after will I send for many hunters, and they shall hunt them from every mountain, and from every hill, and out of the holes of the rocks."},
            {new Reference("Ezekiel", 37, 15, 17), "The word of the Lord came again unto me, saying,\n\nMoreover, thou son of man, take thee one stick, and write upon it, For Judah, and for the children of Israel his companions: then take another stick, and write upon it, For Joseph, the stick of Ephraim, and for all the house of Israel his companions:\n\nAnd join them one to another into one stick; and they shall become one in thine hand."},
            {new Reference("Daniel", 2, 44, 45), " And in the days of these kings shall the God of heaven set up a kingdom, which shall never be destroyed: and the kingdom shall not be left to other people, but it shall break in pieces and consume all these kingdoms, and it shall stand for ever.\n\nForasmuch as thou sawest that the stone was cut out of the mountain without hands, and that it brake in pieces the iron, the brass, the clay, the silver, and the gold; the great God hath made known to the king what shall come to pass hereafter: and the dream is certain, and the interpretation thereof sure."},
            {new Reference("Amos", 3, 7), "Surely the Lord God will do nothing, but he revealeth his secret unto his servants the prophets."},
            {new Reference("Malachi", 3, 8, 10), "Will a man rob God? Yet ye have robbed me. But ye say, Wherein have we robbed thee? In tithes and offerings.\n\nYe are cursed with a curse: for ye have robbed me, even this whole nation.\n\nBring ye all the tithes into the storehouse, that there may be meat in mine house, and prove me now herewith, saith the Lord of hosts, if I will not open you the windows of heaven, and pour you out a blessing, that there shall not be room enough to receive it."},
            {new Reference("Malachi", 4, 5, 6), "Behold, I will send you Elijah the prophet before the coming of the great and dreadful day of the Lord:\n\nAnd he shall turn the heart of the fathers to the children, and the heart of the children to their fathers, lest I come and smite the earth with a curse."},

            // New Testatment
            { new Reference("Matthew", 5, 14, 16), "Ye are the light of the world. A city that is set on an hill cannot be hid.\n\nNeither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house.\n\nLet your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."},
            {new Reference("Matthew", 6, 24), "No man can serve two masters: for either he will hate the one, and love the other; or else he will hold to the one, and despise the other. Ye cannot serve God and mammon."},
            {new Reference("Matthew", 16, 15, 19), "He saith unto them, But whom say ye that I am?\n\nAnd Simon Peter answered and said, Thou art the Christ, the Son of the living God.\n\nAnd Jesus answered and said unto him, Blessed art thou, Simon Bar-jona: for flesh and blood hath not revealed it unto thee, but my Father which is in heaven.\n\nAnd I say also unto thee, That thou art Peter, and upon this rock I will build my church; and the gates of hell shall not prevail against it.\n\nAnd I will give unto thee the keys of the kingdom of heaven: and whatsoever thou shalt bind on earth shall be bound in heaven: and whatsoever thou shalt loose on earth shall be loosed in heaven."},
            {new Reference("Matthew", 25, 40), "And the King shall answer and say unto them, Verily I say unto you, Inasmuch as ye have done it unto one of the least of these my brethren, ye have done it unto me."},
            {new Reference("Luke", 24, 36, 39), "And as they thus spake, Jesus himself stood in the midst of them, and saith unto them, Peace be unto you.\n\nBut they were terrified and affrighted, and supposed that they had seen a spirit.\n\nAnd he said unto them, Why are ye troubled? and why do thoughts arise in your hearts?\n\nBehold my hands and my feet, that it is I myself: handle me, and see; for a spirit hath not flesh and bones, as ye see me have."},
            {new Reference("John", 3, 5), "Jesus answered, Verily, verily, I say unto thee, Except a man be born of water and of the Spirit, he cannot enter into the kingdom of God."},
            {new Reference("John", 7, 17), "If any man will do his will, he shall know of the doctrine, whether it be of God, or whether I speak of myself."},
            {new Reference("John", 10, 16), "And other sheep I have, which are not of this fold: them also I must bring, and they shall hear my voice; and there shall be one fold, and one shepherd."},
            {new Reference("John", 14, 15), "If ye love me, keep my commandments."},
            {new Reference("John", 17, 3), "And this is life eternal, that they might know thee the only true God, and Jesus Christ, whom thou hast sent."},
            {new Reference("Acts", 7, 55, 56), "But he, being full of the Holy Ghost, looked up steadfastly into heaven, and saw the glory of God, and Jesus standing on the right hand of God,\n\nAnd said, Behold, I see the heavens opened, and the Son of man standing on the right hand of God."},
            {new Reference("Romans", 1, 16), "For I am not ashamed of the gospel of Christ: for it is the power of God unto salvation to every one that believeth; to the Jew first, and also to the Greek."},
            {new Reference("1 Corinthians", 10, 13), "There hath no temptation taken you but such as is common to man: but God is faithful, who will not suffer you to be tempted above that ye are able; but will with the temptation also make a way to escape, that ye may be able to bear it."},
            // {new Reference("1 Corinthians", 15, 20, 22), "But now is Christ risen from the dead, and become the firstfruits of them that slept.\n\nFor since by man came death, by man came also the resurrection of the dead.\n\nFor as in Adam all die, even so in Christ shall all be made alive."},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
            // {new Reference()},
        };
    }

    // behaviors (methods)
    public KeyValuePair<Reference, string> Pick()
    {
        var passageList = new List<KeyValuePair<Reference, string>>(_passages);
        int index = _random.Next(passageList.Count);
        return passageList[index];
    }
}