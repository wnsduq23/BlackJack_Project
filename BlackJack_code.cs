using System;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//구상만 하였을 뿐 아직 함수 구현은 제대로 하지 않아
//코드 선언 내용이 아직 틀릴 수도 있음.
namespace Blackjack
{

    class Program
    {
        //카드의 정보를 담고 있는 Card구조체 선언
        public struct Card
        {
            //문양은 스페이드, 다이아몬드, 하트, 클로버가 있다.
            public char shape;
            // 1 to 13
            public int number;
            //숫자는 j,k,q는 10으로, A는 1또는 11로 표현한다.
            //A를 어떤 수로 쓸지는 나중에 구현
            public int value;
        }
        //플레이어의 정보가 담긴 Player 구조체 선언
        public class Player
        {
            //플레이어의 현재 점수 score
            public int score = 0;
            //플레이어가 가지고있는 a의 갯수
            public int ace_cnt = 0;
            public int bet_cash = 0;
            public int card_cnt = 0;
            public bool busted = false; // 플레이어가 버스트 되었는지 여부
            //플레이어가 현재 가지고 있는 카드 정보를 담은 배열 선언
            public Card[] player_cards = new Card[10];

            //카드 받는 메소드 
            public virtual void GetCard(Card card)
            {
                player_cards[card_cnt++] = card;
                UpdateScore();
            }
            // 현재 점수 확인 메소드
            public int UpdateScore()
            {
                //점수가 21을 넘어갈 경우 가지고 있는 ace들의 밸류를 1로 바꿔야하기 때문에 카드를 받을떄마다 점수를 업데이트해줘야한다. 
                score = 0;
                for (int i = 0; i < card_cnt; i++)
                {
                    //현재 가지고 있는 에이스 개수 체크
                    if (player_cards[i].value == 11)
                    {
                        ace_cnt++;
                    }
                    score += player_cards[i].value;
                }
                //합이 21을 넘어간다면
                if (score > 21)
                {
                    //합이 21보다 작아질때까지 a들의 밸류를 1로 바꿈
                    for (int i = 0; i < ace_cnt; i++)
                    {
                        score -= 10;
                        if (score < 21)
                        {
                            break;
                        }
                    }
                    //합 21 넘는다면 버스트
                    if (score > 21)
                    {
                        Bust(this);
                    }
                }
                return score;
            }
        }
        public class Dealer : Player
        {
            public Dealer()
            {
                score = 0;
            }
            public override void GetCard(Card card)
            {
                //딜러의 합이 17보다 작으면 카드를 받고 그렇지 안하면 카드를 그만 받음
                if (this.UpdateScore() < 17)
                {
                    base.GetCard(card);
                }
                else
                {
                    Console.WriteLine("dealer can't get more card");
                }
            }
        }
        public class User : Player
        {
            //배팅을 해야 하기 때문에 현재 소지금 cash
            public double cash;

            public User()
            {
                score = 0;
                cash = 1000;
            }
            //첫 두장의 카드를 보고 그 판을 포기할 지 여부를 파악해주는 함수
            public void Surrender(Dealer dealer)
            {
                if (!BlackJack(dealer))  //딜러가 블랙잭이 아닐시 
                {
                    this.cash += Betting(this) / 2;
                }
            }


        }

        //A카드,2~9, Q, J, K 각각 4장씩 총 52장의 카드가 있다.
        static Card[] all_card = new Card[52];

        //52장의 카드인 all_card 배열에 카드의 정보(해당 카드의 숫자, 모양)를 담아 주기 위한 함수
        static public void PushInformationCard()
        {
            char[] shape = { 's', 'c', 'h', 'd' };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    all_card[i * 13 + j].shape = shape[i];
                    all_card[i * 13 + j].number = j + 1;
                    if ((j + 1) % 14 >= 10)
                    {
                        all_card[i * 13 + j].value = 10;
                    }
                    else if (j == 0)
                    {
                        all_card[i * 13 + j].value = 11;
                    }
                    else
                    {
                        all_card[i * 13 + j].value = j + 1;
                    }
;
                }
            }
        }
        //총 52장의 카드를 섞어 순서를 바꿔 줄 수 있는 함수
        static public void Shuffle()
        {
        }
        //셔플 후 첫번째 카드부터 차례대로 딜러가 분배해주기 위한 카드 순서 deal변수
        public int deal = 0;

        //deal번째 순서의 카드를 딜러가 나눠주도록 하기 위해 해당 순서의 카드를 반환해주는 함수
        public Card Dealing(int deal)
        {
            return all_card[deal];
        }

        //플레이어의 소지금 내에서 배팅 할 수 있도록 해주는 함수, 배팅 금액을 반환해준다.
        static public int Betting(Player player)
        {
            int bet = 0;
            return bet;
        }

        //딜러가 분배한 카드의 정보를 출력하여 볼 수 있게 해주는 함수
        static public void ShowCard(Card card)
        {
        }

        //플레이어가 이후 힛을 할지, 스테이를 할지 결정해주는 함수
        static public void HitOrStay(Player player)
        {
        }

        /*처음 2장의 카드를 받은 이후 더블다운을 결정하면 1장만 힛으로
        더 받기로 하고 배팅을 2배로 한번 더 배팅할 수 있다.
        더블다운을 할 지 여부를 판단해줄 수 있는 함수*/
        static public int Double_down(Player player)
        {
            int bet = Betting(player);
            return bet;
        }


        //블랙잭이 나왔는지 여부를 확인하는 함수
        static public bool BlackJack(Player player)
        {
            if (player.UpdateScore() == 21 && player.card_cnt == 2)  //카드를 두장 가지고 있고 합이 21이면 블랙잭
            {
                return true;
            }
            return false;
        }

        //게임 결과로 누가 승리하였는지 확인해주는 함수
        static public void ResultGame(Dealer dealer, User user)
        {
            Console.WriteLine("{0} {1}", dealer.score, user.score);
            if (BlackJack(dealer) && BlackJack(user))  //딜러와 유저 둘다 블랙잭
            {
                //push(무승부) 배팅금액을 돌려받는다.
                Console.WriteLine("Draw");
                user.cash += user.bet_cash;
            }
            else if (BlackJack(user))
            {
                Console.WriteLine("User Win");
                user.cash += Betting(user) * 2.5;    //유저가 블랙잭으로 이길 경우 배팅 금액 2.5배를 딴다.
            }
            else if (BlackJack(dealer))
            {
                Console.WriteLine("Dealer Win");
            }
            //busted 확인해야함
            else
            {
                if (dealer.score > user.score)
                {
                    Console.WriteLine("Dealer Win");
                }
                else if (dealer.score < user.score)
                {
                    Console.WriteLine("User Win");
                    user.cash += Betting(user) * 2.0;    //유저 승리 배팅금액의 두배를 돌려받는다.
                }
                else
                {
                    //push(무승부) 배팅금액을 돌려받는다.
                    Console.WriteLine("Draw");
                    user.cash += user.bet_cash;
                }
            }
            NewGame(dealer, user);
        }
        // 게임 한판이 끝난 뒤 배팅금액, 플레이어,딜러 카드덱을 비우고 전체카드덱 셔플
        static public void NewGame(Dealer dealer, User user)
        {

            if (user.cash > 0)          //유저가 돈이 남아있다면 새로운 게임 시작
            {
                dealer.card_cnt = 0;
                user.card_cnt = 0;
                dealer.busted = false;
                user.busted = false;
                dealer.ace_cnt = 0;
                user.ace_cnt = 0;
                Shuffle();
            }
            else             //유저가 돈이 없다면 resetgame
            {
                ResetGame();
            }
        }
        //스코어가 21이 넘어 버스트 패배하고 새 게임을 시작한다.
        static public void Bust(Player player)
        {
            Console.WriteLine("Busted");
            if (player.GetType() == typeof(Dealer))
            {
                Console.WriteLine("User Win");
            }
            else if (player.GetType() == typeof(User))
            {
                Console.WriteLine("Dealer Win");
            }
            player.busted = true;  //해당 플레이어의 상태 busted -> 게임종료 시키고 newGame호출 필요함.
        }

        /*첫 두장의 카드가 같을 경우 두 카드를 나눠서 게임하는 
         규칙인데 이 함수는 아직 할지말지 여부 미정*/
        static public void Split()
        {
        }

        //최초 받는 2장의 카드가 같은 가치를 갖는 카드일 거라 예상한다면 미리 페어 배팅 가능
        //페어 배팅할지 여부를 확인해주는 함수
        static public void PairBetting()
        {

        }

        //상대가 블랙잭이 나올걸 대비해 베팅금액의 절반을 인슈어런스로 지불한다.
        //인슈어런스 여부 확인 함수
        static public void Insurance()
        {
        }

        //소지금이 바닥나 게임이 모두 끝나 새 게임을 할 수 있도록 초기화해주는 함수
        static public void ResetGame()
        {
        }

        //게임을 진행해주는 함수
        static public void GameStart()
        {
            /*
            ----------안에서 여러가지 함수 실행되며 게임 진행됨-----------
            -대략적인 진행상황(카드를 받을 때마다 카드의 정보를 show_card를 통해 보여줌, score계산으로 21이 넘는지 계속 확인)-
            카드 셔플 진행 -> 배팅 진행 -> 페어 배팅 여부 확인 -> 플레이어1과 딜러 카드 2장씩 부여받음 -> 서렌더 여부 판단 -> 인슈어런스 여부 판단 -> 
            더블다운 여부 확인 -> hit or stay 여부 확인 -> 등 등 계속 게임 진행 -> 21이 넘지 않고 게임 마무리될경우 result_game으로 결과 확인
             */
        }
        //메인함수에서 game_start 진행
        public static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            User user = new User();

            PushInformationCard();

            while (!user.busted)
            {   //hit or stay
                user.GetCard(all_card[10]);
            }
            if (user.busted)
            {
                NewGame(dealer, user);
            }

            dealer.GetCard(all_card[0]);
            dealer.GetCard(all_card[8]);
            user.GetCard(all_card[0]);
            user.GetCard(all_card[11]);
            Console.WriteLine("user score: {0}", user.score);
            dealer.GetCard(all_card[22]);
            /* foreach (Card card in dealer.player_cards)
             {
                 Console.WriteLine("{0} {1} {2}", card.number, card.shape, card.value);
             }*/
            /* foreach (Card card in all_card)
             {
                 Console.WriteLine("{0} {1} {2}",card.number,card.shape,card.value);
             }*/
            Console.WriteLine(dealer.UpdateScore());
            ResultGame(dealer, user);
            /* Console.WriteLine(user.CheckSum());*/
            ResetGame();
            GameStart();
        }
    }
}