using System;
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
            char shape;
            //숫자는 j,k,q는 10으로, A는 1또는 11로 표현한다.
            //A를 어떤 수로 쓸지는 나중에 구현
            int number;
        }

        //플레이어의 정보가 담긴 Player 구조체 선언
        public struct Player
        {
            //플레이어의 현재 점수 score
            int score;
            //배팅을 해야 하기 때문에 현재 소지금 cash
            int cash;
            //플레이어가 현재 가지고 있는 카드 정보를 담은 배열 선언
            Card[] player_cards = new Card[10];

            public Player()
            {
                score = 0;
                cash = 0;
            }
        }

        //A카드,2~9, Q, J, K 각각 4장씩 총 52장의 카드가 있다.
        Card[] all_card = new Card[52];

        //게임 이용자는 딜러와 배팅하는 이용자로 총 2명으로 가정한다.
        //이 배열에서 딜러는 index=0, 플레이어는 index=1로 설정
        Player[] players = new Player[2];

        //52장의 카드인 all_card 배열에 카드의 정보(해당 카드의 숫자, 모양)를 담아 주기 위한 함수
        public void push_information_card(char Shape, int Number)
        {
            Card card = new Card
            {
                shape = Shape,
                number = Number
            };

            // 생성한 카드를 all_card 배열에 추가
            for (int i = 0; i < all_card.Length; i++)
            {
                if (all_card[i].number == 0)
                {
                    all_card[i] = card;
                    break;
                }
            }
        }
        //총 52장의 카드를 섞어 순서를 바꿔 줄 수 있는 함수
        public void shuffle()
        {
            Random rnd = new Random(); //빌트인 클래스
            for (int i = all_card.Length - 1; i >= 0; i--)
            {
                int j = rnd.Next(i + 1);
                Card temp = all_card[j];
                all_card[j] = all_card[i];
                all_card[i] = temp;
            }
        }

        //셔플 후 첫번째 카드부터 차례대로 딜러가 분배해주기 위한 카드 순서 deal변수
        public int deal = 0;

        //deal번째 순서의 카드를 딜러가 나눠주도록 하기 위해 해당 순서의 카드를 반환해주는 함수
        public Card dealing(int deal)
        {
            return all_card[deal];
        }

        //플레이어의 소지금 내에서 배팅 할 수 있도록 해주는 함수, 배팅 금액을 반환해준다.
        static public int betting(Player player)
        {
            int bet = 0;
            bool isValidBet = false;
            while (!isValidBet)
            {
                Console.Write($"You have {player.cash} cash. Place your bet: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out bet)) // input이 정수형으로 변환될 수 있을때 bet에 값 넣기.
                {
                    if (bet > 0 && bet <= player.cash)
                    {
                        isValidBet = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid bet amount. Bet must be between 1 and {player.cash}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Bet must be a positive integer.");
                }
            }
            player.cash -= bet;
            return bet;
        }


        //딜러가 분배한 카드의 정보를 출력하여 볼 수 있게 해주는 함수
        static public void Show_Card(Player[] players)
        {
            Console.WriteLine("----딜러의 카드----");
            int num_card1 = players[0].player_cards.Length;
            for (int i = 0; i < num_card1; i++)
            {
                Console.Write("{0}{1} ", players[0].player_cards[i].shape, players[0].player_cards[i].number);
            }
            Console.WriteLine();
            Console.WriteLine("----딜러의 점수----");
            Console.Write(players[0].score);


            Console.WriteLine("----플레이어의 카드----");
            int num_card2 = players[1].player_cards.Length;
            for (int i = 0; i < num_card2; i++)
            {
                Console.Write("{0}{1} ", players[1].player_cards[i].shape, players[1].player_cards[i].number);
            }
            Console.WriteLine();
            Console.WriteLine("----플레이어의 점수----");
            Console.Write(players[1].score);


        }


        static public void Hit(Player player, Card[] all_card)
        {
            int num_cards = player.player_cards.Length;
            player.player_cards[num_cards] = all_card[deal];
        }


        //플레이어가 이후 힛을 할지, 스테이를 할지 결정해주는 함수
        static public int HitOrSstay(Player player)
        {
            Console.WriteLine("----Hit 또는 Stay를 입력하여 결정해주세요.----");
            string hit_or_stay = Console.ReadLine();
            if (hit_or_stay == "Hit")
            {
                Hit(player, all_card);
                return 1;
            }
            else if (hit_or_stay == "Stay")
            {
                return 0;
            }
            else
            {
                Console.WriteLine("----잘못된 명령어가 입력되었습니다.----");
                Console.WriteLine("----다시 입력해주세요.----");
                return -1;
            }
        }


        /*처음 2장의 카드를 받은 이후 더블다운을 결정하면 1장만 힛으로
        더 받기로 하고 배팅을 2배로 한번 더 배팅할 수 있다.
        더블다운을 할 지 여부를 판단해줄 수 있는 함수*/
        static public int Doubledown(Player player)
        {
            Console.WriteLine("----더블다운을 하시겠습니까?----");
            Console.WriteLine("----Yes or No로 입력해주세요.----");
            string double_down = Console.ReadLine();
            if (double_down == "Yes")
            {
                Hit(player, all_card);
                Betting(player);
                return 1;
            }
            else
                return 0;
        }

        //첫 두장의 카드를 보고 그 판을 포기할 지 여부를 파악해주는 함수
        static public void surrender(Player player)
        {
        }

        //블랙잭이 나왔는지 여부를 확인하는 함수
        static public void black_jack(Player player)
        {
        }

        //게임 결과로 누가 승리하였는지 확인해주는 함수
        static public void result_game()
        {
        }

        /*첫 두장의 카드가 같을 경우 두 카드를 나눠서 게임하는 
         규칙인데 이 함수는 아직 할지말지 여부 미정*/
        static public void split()
        {
        }

        //최초 받는 2장의 카드가 같은 가치를 갖는 카드일 거라 예상한다면 미리 페어 배팅 가능
        //페어 배팅할지 여부를 확인해주는 함수
        static public void PairBetting()
        {
            Console.WriteLine("You have a pair! You can make a pair bet up to your original bet.");
            int pair_bet = AskForPairBet();
            //pair betting을 하였다면
            if (pair_bet > 0 && pair_bet <= player_bet)
            {
                Console.WriteLine("You bet {0} on your pair.", pairBet);
            }
        }
        //이 돈을 받는 시점이 두 번째 카드가 공개된 시점이여서 확인과정 함수를 따로 나눔
        static public void CheckPairBetting()
        {
            // 베팅한 금액의 11배를 받는다. 
            if (player_card1 == player_card2)
                player_money += pair_bet * 11;
            else
                player_money -= pair_bet;
        }

        //상대가 블랙잭이 나올걸 대비해 베팅금액의 절반까지 인슈어런스로 지불할 수 있다.
        //인슈어런스 여부 확인 함수
        private bool dealer_has_ace;
        static public void Insuarance()
        {
            //딜러의 업카드가 Ace일 때 유저에게 묻는다.
            if (dealer_has_ace)
            {
                if (AsKForInsurance())
                {
                    Conosole.WriteLine("You bought insurance.");
                    //인슈어런스에 얼마를 베팅할지 (찾아보니 절반까지 배팅할 수 있는 듯?)
                    int a = PlayerBettingToInsurance();
                    //만약 딜러가 블랙잭이 맞았다면 
                    if (dealer_score == 10)
                    {
                        Console.WriteLine("Dealer has blackjack. Insurance pays 2 to 1.");
                        player_money += a * 2;
                        player_betting_money = 0;
                    }
                    // 블랙잭이 아니였다면 
                    else
                    {
                        Console.WriteLine("Dealer does not have blackjack. You lose your insurance bet.");
                        player_money -= a;
                        //플레이어가 블랙잭이였다면 
                        if (player_score == 21)
                            player_money += player_betting_money * 1.5;

                    }
                }
            }
        }
        private int PlayerBettingToInsurance()
        {
            Console.WriteLine("How much do you want to bet on insurance?");
            string a = Console.ReadLine();
            return (int.Parse(a));
        }


        //소지금이 바닥나 게임이 모두 끝나 새 게임을 할 수 있도록 초기화해주는 함수
        //소지금이 바닥난 경우는 여기가 아니라, 모든 user_money 계산 후에 0보다 작거나 같아지면 종료 확인을 해야할듯 ? 
        static public void reset_game()
        {
            dealer_card = 0;
            player_score = 0;
            dealer_score = 0;
            dealer_has_ace = false;

            // 딜러랑 플레이어에게 카드 주기 
            int player_card1 = GetRandomCard();
            int player_card2 = GetRandomCard();
            int dealer_card1 = GetRandomCard();
            dealer_card = dealer_card1; // remember dealer's first card

            player_score = player_card1 + player_card2;
            dealer_score = dealer_card1;
            dealer_has_ace = (dealer_card1 == 1);

            //어떤 값 들어왔는 지 확인. 후에 딜러 카드 확인은 유저가 못하게 해야할 듯 
            Console.WriteLine("Your cards: {0} and {1} (total = {2})", player_card1, player_card2, player_score);
            Console.WriteLine("Dealer's card: {0}", dealer_card1);
        }

        //게임을 진행해주는 함수
        static public void game_start()
        {
            /*
            ----------안에서 여러가지 함수 실행되며 게임 진행됨-----------
            -대략적인 진행상황(카드를 받을 때마다 카드의 정보를 show_card를 통해 보여줌, score계산으로 21이 넘는지 계속 확인)-
            카드 셔플 진행 -> 배팅 진행 -> 페어 배팅 여부 확인 -> 플레이어1과 딜러 카드 2장씩 부여받음 -> 서렌더 여부 판단 -> 인슈어런스 여부 판단 -> 
            더블다운 여부 확인 -> hit or stay 여부 확인 -> 등 등 계속 게임 진행 -> 21이 넘지 않고 게임 마무리될경우 result_game으로 결과 확인
             */
        }
        //메인함수에서 game_start 진행
        static void Main(string[] args)
        {
            reset_game();
            game_start();
        }
    }
}