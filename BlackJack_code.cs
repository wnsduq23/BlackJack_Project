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
        public void push_information_card()
        {
        }
        //총 52장의 카드를 섞어 순서를 바꿔 줄 수 있는 함수
        public void shuffle()
        {
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
            int bet=0;
            return bet;
        }

        //딜러가 분배한 카드의 정보를 출력하여 볼 수 있게 해주는 함수
        static public void show_card(Card card)
        {
        }

        //플레이어가 이후 힛을 할지, 스테이를 할지 결정해주는 함수
        static public void hit_or_stay(Player player)
        {
        }

        /*처음 2장의 카드를 받은 이후 더블다운을 결정하면 1장만 힛으로
        더 받기로 하고 배팅을 2배로 한번 더 배팅할 수 있다.
        더블다운을 할 지 여부를 판단해줄 수 있는 함수*/
        static public int Double_down(Player player)
        {
            int bet = betting(player);
            return bet;
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
        static public void pair_betting()
        {
            
        }

        //상대가 블랙잭이 나올걸 대비해 베팅금액의 절반을 인슈어런스로 지불한다.
        //인슈어런스 여부 확인 함수
        static public void insuarance()
        {
        }

        //소지금이 바닥나 게임이 모두 끝나 새 게임을 할 수 있도록 초기화해주는 함수
        static public void reset_game()
        {
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