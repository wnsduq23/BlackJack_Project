﻿using Blackjack;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BP = Blackjack.Program;

namespace blackjack_windform
{
    public partial class GamePage : Form
    {
        public static int bet_amount = 0;
        public GamePage()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void GamePage_Load(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();


            bet_amount = 1;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 5;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 10;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 50;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 100;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 500;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }
        static void showResult(BP.Dealer dealer, BP.User user)
        {
            string result;
            result = BP.ResultGame(dealer, user);
            MessageBox.Show(result);
        }
        static void clearImg()
        {

        }
        static void NewGame(BP.Dealer dealer, BP.User user)
        {
            BP.NewGame(dealer, user);
            clearImg();
        }
        static bool Surrender(BP.Dealer dealer, BP.User user)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to surrender?", "Surrender", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                user.Surrender(dealer);
                return true;
            }
            else
            {
                return false;
            }

        }
        static public void GameStart()
        {
            /*
            ----------안에서 여러가지 함수 실행되며 게임 진행됨-----------
            -대략적인 진행상황(카드를 받을 때마다 카드의 정보를 show_card를 통해 보여줌, score계산으로 21이 넘는지 계속 확인)-
            카드 셔플 진행 -> 배팅 진행 -> 페어 배팅 여부 확인 -> 플레이어1과 딜러 카드 2장씩 부여받음 -> 서렌더 여부 판단 -> 인슈어런스 여부 판단 -> 
            더블다운 여부 확인 -> hit or stay 여부 확인 -> 등 등 계속 게임 진행 -> 21이 넘지 않고 게임 마무리될경우 result_game으로 결과 확인
             */
            int dealing;
            int pair_bet;
            bool surrender;
            char[] shape = { 's', 'c', 'h', 'd' };
            BP.User user = new BP.User();
            BP.Dealer dealer = new BP.Dealer();

            for (int i = 0; i < 4; i++)           //카드 정보입력
            {
                for (int j = 0; j < 13; j++)
                {
                    BP.PushInformationCard(shape[i], j + 1);
                }
            }
            while (user.cash > 0)        // 유저 잔고가 0이상일 경우 계속 게임을 할 수 있다.
            {
                dealing = 0;  //나눠줄 올카드 인덱스
                BP.Shuffle();  //카드를 섞는다. 
                user.bet_cash = BP.Betting(user, 1);       //배팅

                user.pair_bet = BP.PairBetting(user);

                dealer.GetCard(BP.all_card[dealing++]);          //딜러와 유저 카드 두장씩 받는다.
                // dealer가 ace카드 일 때의 예시 넣기
                //딜러의 카드가 ace일때 insurance 할지
                BP.Insuarance(dealer, user);

                dealer.GetCard(BP.all_card[dealing++]);
                user.GetCard(BP.all_card[dealing++]);
                user.GetCard(BP.all_card[dealing++]);

                if (user.insurance_bet > 0)
                    BP.CheckInsuranceBetting(dealer, user);
                if (user.pair_bet > 0)
                    BP.CheckPairBetting(user);


                surrender = Surrender(dealer, user);

                if (surrender)
                {
                    BP.NewGame(dealer, user);
                    continue;
                }
                dealing = BP.DoubleDown(user, dealing);

                while (!user.busted && !user.stay)             //유저가 버스트되던가 stay를 외칠때까지 HitOrStay 반복
                {
                    dealing = BP.HitOrStay(user, dealing);
                }

                if (user.busted)            //유저가 버스트 되었다면 게임 종료
                {
                    BP.NewGame(dealer, user);
                    continue;
                }

                while (!dealer.busted && dealer.score < 17)    //유저가 카드 받기를 멈췄고 버스트되지 않았다면 점수가 17이상이 될떄까지 딜러가 카드를 받기 시작한다.
                {
                    dealer.GetCard(BP.all_card[dealing++]);
                }
                showResult(dealer, user); //게임 결과
                NewGame(dealer, user);


            }

        }
        private void GamePage_Shown(object sender, EventArgs e)
        {
            GameStart();
        }
    }

}
