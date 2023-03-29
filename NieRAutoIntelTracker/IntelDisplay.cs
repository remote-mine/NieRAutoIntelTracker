using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace NieRAutoIntelTracker
{
    public partial class IntelDisplay : Form
    {
        public IntelDisplay()
        {
            InitializeComponent();
#if !DEBUG
            this.debugValue.Visible = false;
            this.debugValue2.Visible = false;
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ToggleVisibility()
        {
            this.Visible = !this.Visible;
        }

        public void SetVisibility(bool visible)
        {
            this.Visible = visible;
        }

        public void UpdateFishIntel(byte[] buffer, int count)
        {
            this.checkBoxMackerelM2.Checked = (buffer[0] & (byte)FishIntel.MACKEREL_MACHINE) != 0;
            this.checkBoxCoelacanthM.Checked = (buffer[0] & (byte)FishIntel.COELACANTH_MACHINE) != 0;
            this.checkBoxBreamM2.Checked = (buffer[0] & (byte)FishIntel.BREAM_MACHINE) != 0;
            this.checkBoxStarfishM2.Checked = (buffer[0] & (byte)FishIntel.STARFISH_MACHINE) != 0;
            this.checkBoxSwordfishM.Checked = (buffer[0] & (byte)FishIntel.SWORDFISH_MACHINE) != 0;
            this.checkBoxBlowfishM2.Checked = (buffer[0] & (byte)FishIntel.BLOWFISH_MACHINE) != 0;
            this.checkBoxBloatFishM3.Checked = (buffer[0] & (byte)FishIntel.BLOAT_FISH_MACHINE) != 0;
            this.checkBoxCarpM4.Checked = (buffer[0] & (byte)FishIntel.CARP_MACHINE) != 0;

            this.checkBoxArapaimaM3.Checked = (buffer[1] & (byte)FishIntel.ARAPAIMA_MACHINE) != 0;
            this.checkBoxKoiCarpM5.Checked = (buffer[1] & (byte)FishIntel.KOI_CARP_MACHINE) != 0;
            this.checkBoxKillifishM.Checked = (buffer[1] & (byte)FishIntel.KILLIFISH_MACHINE) != 0;
            this.checkBoxBaskingShark.Checked = (buffer[1] & (byte)FishIntel.BASKING_SHARK) != 0;
            this.checkBoxBream.Checked = (buffer[1] & (byte)FishIntel.BREAM) != 0;
            this.checkBoxStarfish.Checked = (buffer[1] & (byte)FishIntel.STARFISH) != 0;
            this.checkBoxBeetleFish.Checked = (buffer[1] & (byte)FishIntel.BEETLE_FISH) != 0;
            this.checkBoxHorseshoeCrab.Checked = (buffer[1] & (byte)FishIntel.HORSESHOE_CRAB) != 0;

            this.checkBoxMackerel.Checked = (buffer[2] & (byte)FishIntel.MACKEREL) != 0;
            this.checkBoxSwordfish.Checked = (buffer[2] & (byte)FishIntel.SWORDFISH) != 0;
            this.checkBoxBlowfish.Checked = (buffer[2] & (byte)FishIntel.BLOWFISH) != 0;
            this.checkBoxCoelacanth.Checked = (buffer[2] & (byte)FishIntel.COELACANTH) != 0;
            this.checkBoxTwoface.Checked = (buffer[2] & (byte)FishIntel.TWOFACE) != 0;
            this.checkBoxWaterFlea.Checked = (buffer[2] & (byte)FishIntel.WATER_FLEA) != 0;
            this.checkBoxOilSardine.Checked = (buffer[2] & (byte)FishIntel.OIL_SARDINE) != 0;
            this.checkBoxArapaima.Checked = (buffer[2] & (byte)FishIntel.ARAPAIMA) != 0;

            this.checkBoxFreshwaterRay.Checked = (buffer[3] & (byte)FishIntel.FRESHWATER_RAY) != 0;
            this.checkBoxFurCarp2.Checked = (buffer[3] & (byte)FishIntel.FUR_CARP) != 0;
            this.checkBoxKoiCarp6.Checked = (buffer[3] & (byte)FishIntel.KOI_CARP) != 0;
            this.checkBoxBloatFish.Checked = (buffer[3] & (byte)FishIntel.BLOAT_FISH) != 0;
            this.checkBoxCarp6.Checked = (buffer[3] & (byte)FishIntel.CARP) != 0;
            this.checkBoxKillifish6.Checked = (buffer[3] & (byte)FishIntel.KILLIFISH) != 0;
            this.checkBoxTwinfish.Checked = (buffer[3] & (byte)FishIntel.TWINFISH) != 0;
            this.checkBoxArowana4.Checked = (buffer[3] & (byte)FishIntel.AROWANA) != 0;

            this.checkBoxIronPipe.Checked = (buffer[6] & (byte)FishIntel.IRON_PIPE) != 0;
            this.checkBoxPodB.Checked = (buffer[6] & (byte)FishIntel.POD_B) != 0;
            this.checkBoxBrokenFirearm.Checked = (buffer[6] & (byte)FishIntel.BROKEN_FIREARM) != 0;

            this.checkBoxBattery2.Checked = (buffer[7] & (byte)FishIntel.BATTERY) != 0;
            this.checkBoxGasCylinder.Checked = (buffer[7] & (byte)FishIntel.GAS_CYLINDER) != 0;
            this.checkBoxTire2.Checked = (buffer[7] & (byte)FishIntel.TIRE) != 0;
            this.checkBoxMachineHead.Checked = (buffer[7] & (byte)FishIntel.MACHINE_LIFEFORM_HEAD) != 0;
            this.checkBoxFreshwaterRayM.Checked = (buffer[7] & (byte)FishIntel.FRESHWATER_RAY_MACHINE) != 0;
            this.checkBoxBaskingSharkM.Checked = (buffer[7] & (byte)FishIntel.BASKING_SHARK_MACHINE) != 0;
            this.checkBoxArowanaM.Checked = (buffer[7] & (byte)FishIntel.AROWANA_MACHINE) != 0;
            this.checkBoxHorseshoeCrabM.Checked = (buffer[7] & (byte)FishIntel.HORSESHOE_CRAB_MACHINE) != 0;

            this.textProgressBarFish.Value = count;
        }

        public void UpdateDebugDisplay(string text)
        {
            this.debugValue.Text = text;
        }

        public void UpdateUnitIntel(byte[] buffer)
        {
            this.checkBoxSmallStubby.Checked = (buffer[3] & 128) != 0;
            this.checkBoxSmallStubbyGunEquipped.Checked = (buffer[3] & 64) != 0;
            this.checkBoxSmallStubbyShieldEquipped.Checked = (buffer[3] & 32) != 0;
            this.checkBoxSmallStubbyElectromagneticshieldequipped.Checked = (buffer[3] & 16) != 0;
            this.checkBoxMultitierType.Checked = (buffer[3] & 8) != 0;
            this.checkBoxMultitierTypeGunEquipped.Checked = (buffer[3] & 4) != 0;
            this.checkBoxSmallBiped.Checked = (buffer[3] & 1) != 0;
            this.checkBoxSmallBipedTorchEquipped.Checked = (buffer[20] & 1) != 0;
            this.checkBoxMediumBiped.Checked = (buffer[2] & 128) != 0;
            this.checkBoxMediumBipedShieldEquipped.Checked = (buffer[2] & 64) != 0;
            this.checkBoxMediumBipedElectromagneticShieldEquipped.Checked = (buffer[2] & 32) != 0;
            this.checkBoxMediumQuadruped.Checked = (buffer[2] & 16) != 0;
            this.checkBoxMediumQuadrupedstanding.Checked = (buffer[2] & 8) != 0;
            this.checkBoxMultilegMediummodelLongrange.Checked = (buffer[2] & 4) != 0;
            this.checkBoxMultilegMediummodelCloserange.Checked = (buffer[2] & 2) != 0;
            this.checkBoxGoliathBiped.Checked = (buffer[2] & 1) != 0;
            this.checkBoxGoliathBipedEnhancedLegpowerModel.Checked = (buffer[1] & 128) != 0;
            this.checkBoxReversejointedGoliath.Checked = (buffer[1] & 64) != 0;
            this.checkBoxSmallFlyer.Checked = (buffer[1] & 32) != 0;
            this.checkBoxMediumFlyer.Checked = (buffer[1] & 16) != 0;
            this.checkBoxMediumFlyerKamikazeUnit.Checked = (buffer[1] & 8) != 0;
            this.checkBoxMediumFlyerGunnerx2Kamikazex2.Checked = (buffer[1] & 4) != 0;
            this.checkBoxSmallExploder.Checked = (buffer[1] & 2) != 0;
            this.checkBoxMediumExploder.Checked = (buffer[1] & 1) != 0;
            this.checkBoxSmallSphereAxequipped.Checked = (buffer[0] & 128) != 0;
            this.checkBoxSmallSphereDrillequipped.Checked = (buffer[0] & 64) != 0;
            this.checkBoxSmallSphereGunequipped.Checked = (buffer[0] & 32) != 0;
            this.checkBoxLinkedsphereTypeSawequipped.Checked = (buffer[0] & 16) != 0;
            this.checkBoxLinkedsphereTypeDrillequipped.Checked = (buffer[0] & 8) != 0;
            this.checkBoxLinkedsphereTypeThornequipped.Checked = (buffer[0] & 4) != 0;
            this.checkBoxLinkedsphereTypeGunequipped.Checked = (buffer[0] & 2) != 0;
            this.checkBoxRampagingSmallStubby.Checked = (buffer[21] & 4) != 0;
            this.checkBoxRampagingSmallBiped.Checked = (buffer[21] & 2) != 0;
            this.checkBoxRampagingMediumBiped.Checked = (buffer[21] & 1) != 0;
            int countStdMultiTier = this.checkBoxMultitierType.Checked ? 2 : 0;
            int countStd = countStdMultiTier + BitCount.PrecomputedBitcount(buffer[3] & 0xF5) + BitCount.PrecomputedBitcount(buffer[2]) + BitCount.PrecomputedBitcount(buffer[1]) + BitCount.PrecomputedBitcount(buffer[0] & 0xFE) + BitCount.PrecomputedBitcount((byte)(buffer[21] & 7)) + (int) (buffer[20] & 1);
            this.textProgressBarStd.Value = countStd;

            this.checkBoxDesertSmallStubby.Checked = (buffer[7] & 128) != 0;
            this.checkBoxDesertSmallStubbySaw.Checked = (buffer[0] & 1) != 0;
            this.checkBoxDesertSmallBipedSword.Checked = (buffer[7] & 64) != 0;
            this.checkBoxDesertMediumBipedSword.Checked = (buffer[7] & 32) != 0;
            this.checkBoxDesertMediumBipedShield.Checked = (buffer[7] & 16) != 0;
            this.checkBoxDesertMediumBipedEMShield.Checked = (buffer[7] & 8) != 0;
            this.checkBoxDesertGoliathBiped.Checked = (buffer[7] & 4) != 0;
            this.checkBoxDesertSmallFlyer.Checked = (buffer[7] & 2) != 0;
            this.checkBoxDesertMediumFlyer.Checked = (buffer[7] & 1) != 0;
            this.checkBoxDesertMediumFlyerKamikazeUnit.Checked = (buffer[6] & 128) != 0;
            this.checkBoxDesertMediumFlyerGunnerx2Kamikazex2.Checked = (buffer[6] & 64) != 0;
            int countDesert = BitCount.PrecomputedBitcount(buffer[0] & 1) + BitCount.PrecomputedBitcount(buffer[7]) + BitCount.PrecomputedBitcount(buffer[6] & 0xC0);
            this.textProgressBarDesert.Value = countDesert;

            this.checkBoxParkSmallStubby.Checked = (buffer[6] & 32) != 0;
            this.checkBoxParkSmallBiped.Checked = (buffer[6] & 16) != 0;
            this.checkBoxParkMediumBipedGun.Checked = (buffer[6] & 8) != 0;
            this.checkBoxParkSmallFlyer.Checked = (buffer[6] & 4) != 0;
            this.checkBoxParkMediumFlyer.Checked = (buffer[6] & 2) != 0;
            this.checkBoxParkMediumFlyerKamikazeUnit.Checked = (buffer[6] & 1) != 0;
            this.checkBoxParkMediumFlyerGunnerx2Kamikazex2.Checked = (buffer[5] & 128) != 0;
            this.checkBoxParkRampagingSmallBiped.Checked = (buffer[20] & 128) != 0;
            this.checkBoxParkRampagingMediumBiped.Checked = (buffer[20] & 64) != 0;
            int countPark = BitCount.PrecomputedBitcount(buffer[6] & 0x3F) + BitCount.PrecomputedBitcount(buffer[5] & 0x80) + BitCount.PrecomputedBitcount(buffer[20] & 0xC0);
            this.textProgressBarPark.Value = countPark;

            this.checkBoxForestSmallStubby.Checked = (buffer[5] & 64) != 0;
            this.checkBoxForestSmallBipedSpear.Checked = (buffer[5] & 32) != 0;
            this.checkBoxForestMediumBipedSpear.Checked = (buffer[5] & 16) != 0;
            this.checkBoxForestMediumBipedShield.Checked = (buffer[5] & 8) != 0;
            this.checkBoxForestMediumBipedEMShield.Checked = (buffer[5] & 4) != 0;
            this.checkBoxForestMediumQuadruped.Checked = (buffer[5] & 2) != 0;
            this.checkBoxForestMediumQuadrupedRider.Checked = (buffer[5] & 1) != 0;
            this.checkBoxForestMediumQuadrupedStanding.Checked = (buffer[4] & 128) != 0;
            this.checkBoxForestGoliathBipedEnhancedLegpower.Checked = (buffer[4] & 64) != 0;
            this.checkBoxForestSmallFlyer.Checked = (buffer[4] & 32) != 0;
            int countForest = BitCount.PrecomputedBitcount(buffer[5] & 0x7F) + BitCount.PrecomputedBitcount(buffer[4] & 0xE0);
            this.textProgressBarForest.Value = countForest;

            this.checkBoxFactorySmallStubby.Checked = (buffer[20] & 16) != 0;
            this.checkBoxFactorySmallStubbyKamikaze.Checked = (buffer[20] & 8) != 0;
            this.checkBoxFactorySmallBipedTorch.Checked = (buffer[4] & 16) != 0;
            this.checkBoxFactorySmallBipedAxe.Checked = (buffer[4] & 8) != 0;
            this.checkBoxFactoryMediumBipedAxe.Checked = (buffer[4] & 4) != 0;
            this.checkBoxFactoryMediumQuadruped.Checked = (buffer[4] & 2) != 0;
            this.checkBoxFactorySmallFlyer.Checked = (buffer[4] & 1) != 0;
            int countFactory = BitCount.PrecomputedBitcount(buffer[20] & 0x18) + BitCount.PrecomputedBitcount(buffer[4] & 0x1F);
            this.textProgressBarFactory.Value = countFactory;

            this.checkBoxVillageSmallStubby.Checked = (buffer[11] & 128) != 0;
            this.checkBoxVillageMultitier.Checked = (buffer[11] & 64) != 0;
            this.checkBoxVillageSmallBiped.Checked = (buffer[11] & 32) != 0;
            this.checkBoxVillageMediumBiped.Checked = (buffer[11] & 16) != 0;
            this.checkBoxVillageGoliathBiped.Checked = (buffer[11] & 8) != 0;
            this.checkBoxVillageSmallFlyer.Checked = (buffer[11] & 4) != 0;
            this.checkBoxVillageSmallSphere.Checked = (buffer[11] & 2) != 0;
            this.checkBoxVillageSartreJeanPaul.Checked = (buffer[11] & 1) != 0;
            this.checkBoxVillagePascal.Checked = (buffer[10] & 128) != 0;
            this.checkBoxVillagePascalFlying.Checked = (buffer[10] & 64) != 0;
            this.checkBoxVillageFatherMachine.Checked = (buffer[10] & 32) != 0;
            this.checkBoxVillageMotherMachine.Checked = (buffer[10] & 16) != 0;
            this.checkBoxVillageChildMachine.Checked = (buffer[10] & 16) != 0;
            this.checkBoxVillageBigSisterMachine.Checked = (buffer[10] & 4) != 0;
            this.checkBoxVillageLittleSisterMachine.Checked = (buffer[10] & 4) != 0;
            this.checkBoxVillageScientistMachine.Checked = (buffer[10] & 1) != 0;
            this.checkBoxVillageWeirdMachine.Checked = (buffer[9] & 128) != 0;
            int countMotherChild = this.checkBoxVillageMotherMachine.Checked ? 2 : 0;
            int countSisters = this.checkBoxVillageBigSisterMachine.Checked ? 2 : 0;
            int countVillage = countMotherChild + countSisters + BitCount.PrecomputedBitcount(buffer[11]) + BitCount.PrecomputedBitcount(buffer[10] & 0xE1) + BitCount.PrecomputedBitcount(buffer[9] & 0x80);
            this.textProgressBarVillage.Value = countVillage;

            this.checkBoxEnhancedSmallStubby.Checked = (buffer[9] & 4) != 0;
            this.checkBoxEnhancedMultitierType.Checked = (buffer[9] & 2) != 0;
            this.checkBoxEnhancedMultitierTypeGun.Checked = (buffer[9] & 1) != 0;
            this.checkBoxEnhancedSmallBiped.Checked = (buffer[8] & 64) != 0;
            this.checkBoxEnhancedMediumBiped.Checked = (buffer[8] & 32) != 0;
            this.checkBoxEnhancedMediumQuadruped.Checked = (buffer[8] & 16) != 0;
            this.checkBoxEnhancedMediumQuadrupedstanding.Checked = (buffer[20] & 4) != 0;
            this.checkBoxEnhancedMultilegMediumModelLongrange.Checked = (buffer[8] & 8) != 0;
            this.checkBoxEnhancedMultilegMediumModelCloserange.Checked = (buffer[8] & 4) != 0;
            this.checkBoxEnhancedGoliathBiped.Checked = (buffer[8] & 2) != 0;
            this.checkBoxEnhancedGoliathBipedEnhancedLegpower.Checked = (buffer[20] & 2) != 0;
            this.checkBoxEnhancedReversejointedGoliath.Checked = (buffer[8] & 1) != 0;
            this.checkBoxEnhancedSmallFlyer.Checked = (buffer[15] & 128) != 0;
            this.checkBoxEnhancedMediumFlyer.Checked = (buffer[15] & 64) != 0;
            this.checkBoxEnhancedMediumFlyerKamikaze.Checked = (buffer[15] & 32) != 0;
            this.checkBoxEnhancedMediumFlyerGunnerx2Kamikazex2.Checked = (buffer[15] & 16) != 0;
            this.checkBoxEnhancedSmallSphereAxe.Checked = (buffer[15] & 8) != 0;
            this.checkBoxEnhancedSmallSphereDrill.Checked = (buffer[15] & 4) != 0;
            this.checkBoxEnhancedSmallSphereGun.Checked = (buffer[15] & 2) != 0;
            this.checkBoxEnhancedLinkedsphereTypeSaw.Checked = (buffer[15] & 1) != 0;
            this.checkBoxEnhancedLinkedsphereTypeDrill.Checked = (buffer[14] & 128) != 0;
            this.checkBoxEnhancedLinkedsphereTypeGun.Checked = (buffer[14] & 64) != 0;
            this.checkBoxEnhancedLinkedsphereTypeThorn.Checked = (buffer[14] & 32) != 0;
            int countEnhancedMultitier = this.checkBoxEnhancedMultitierType.Checked ? 2 : 0;
            int countEnhanced = countEnhancedMultitier + BitCount.PrecomputedBitcount(buffer[8] & 0x7F) + BitCount.PrecomputedBitcount(buffer[9] & 0x05) + BitCount.PrecomputedBitcount(buffer[20] & 0x06) + BitCount.PrecomputedBitcount(buffer[15]) + BitCount.PrecomputedBitcount(buffer[14] & 0xE0);
            this.textProgressBarEnhanced.Value = countEnhanced;

            this.checkBoxEMPSmallStubby.Checked = (buffer[14] & 16) != 0;
            this.checkBoxEMPSmallBiped.Checked = (buffer[14] & 8) != 0;
            this.checkBoxEMPMediumBiped.Checked = (buffer[14] & 4) != 0;
            this.checkBoxEMPGoliathBiped.Checked = (buffer[14] & 2) != 0;
            int countEMP = BitCount.PrecomputedBitcount(buffer[14] & 0x1E);
            this.textProgressBarEMP.Value = countEMP;

            this.checkBoxSpecialMarx.Checked = (buffer[14] & 1) != 0;
            this.checkBoxSpecialEngels.Checked = (buffer[13] & 128) != 0;
            this.checkBoxSpecialAdamFirstEncounter.Checked = (buffer[13] & 64) != 0;
            this.checkBoxSpecialAdamBattleintheAlienShip.Checked = (buffer[13] & 32) != 0;
            this.checkBoxSpecialAdamFinalBattle.Checked = (buffer[13] & 16) != 0;
            this.checkBoxSpecialEveFirstEncounter.Checked = (buffer[13] & 64) != 0;
            this.checkBoxSpecialEveBattleintheAlienShip.Checked = (buffer[13] & 8) != 0;
            this.checkBoxSpecialEveFinalBattle.Checked = (buffer[13] & 4) != 0;
            this.checkBoxSpecialEveFinalBattle2.Checked = (buffer[13] & 2) != 0;
            this.checkBoxSpecialGoliathTankAmusementPark.Checked = (buffer[13] & 1) != 0;
            this.checkBoxSpecialBeauvoirSimone.Checked = (buffer[12] & 128) != 0;
            this.checkBoxSpecialGoliathFlyer.Checked = (buffer[12] & 64) != 0;
            this.checkBoxSpecialGrun.Checked = (buffer[12] & 32) != 0;
            this.checkBoxSpecialImmanuel.Checked = (buffer[12] & 16) != 0;
            this.checkBoxSpecialErnst.Checked = (buffer[12] & 8) != 0;
            this.checkBoxSpecialKierkegaard.Checked = (buffer[12] & 4) != 0;
            this.checkBoxSpecialSoShi.Checked = (buffer[12] & 2) != 0;
            this.checkBoxSpecialBokuShi.Checked = (buffer[12] & 1) != 0;
            this.checkBoxSpecialHegel.Checked = (buffer[19] & 128) != 0;
            this.checkBoxSpecialHegel2.Checked = (buffer[19] & 64) != 0;
            this.checkBoxSpecialGoliathTank.Checked = (buffer[19] & 32) != 0;
            this.checkBoxSpecialAuguste.Checked = (buffer[19] & 16) != 0;
            this.checkBoxSpecialFriedrich.Checked = (buffer[19] & 16) != 0;
            this.checkBoxSpecialKoShi.Checked = (buffer[19] & 4) != 0;
            this.checkBoxSpecialRoShi.Checked = (buffer[19] & 4) != 0;
            this.checkBoxSpecialKoShiRoshi.Checked = (buffer[19] & 4) != 0;
            this.checkBoxSpecialRedGirl.Checked = (buffer[18] & 128) != 0;
            int countAuguste = this.checkBoxSpecialAuguste.Checked ? 2 : 0;
            int countKoShi = this.checkBoxSpecialKoShi.Checked ? 2 : 0;
            int countSpecial = countAuguste + countKoShi + BitCount.PrecomputedBitcount(buffer[14] & 0x01) + BitCount.PrecomputedBitcount(buffer[13]) + BitCount.PrecomputedBitcount(buffer[12]) + BitCount.PrecomputedBitcount(buffer[19] & 0xE4) + BitCount.PrecomputedBitcount(buffer[18] & 0x80);
            this.textProgressBarSpecial.Value = countSpecial;

            this.checkBoxAndroidYoRHaStandardArmament.Checked = (buffer[18] & 64) != 0;
            this.checkBoxAndroidYoRHaHeavyArmament.Checked = (buffer[18] & 32) != 0;
            this.checkBoxAndroidYoRHaHeavyArmament2.Checked = (buffer[18] & 16) != 0;
            this.checkBoxAndroidYoRHaFlightUnit.Checked = (buffer[18] & 8) != 0;
            this.checkBoxAndroidYoRHaOperator.Checked = (buffer[18] & 4) != 0;
            this.checkBoxAndroid8B.Checked = (buffer[18] & 2) != 0;
            this.checkBoxAndroid22B.Checked = (buffer[18] & 2) != 0;
            this.checkBoxAndroid64B.Checked = (buffer[18] & 2) != 0;
            this.checkBoxAndroid21O.Checked = (buffer[17] & 64) != 0;
            this.checkBoxAndroid2BCopy.Checked = (buffer[17] & 32) != 0;
            this.checkBoxAndroid9S.Checked = (buffer[17] & 16) != 0;
            this.checkBoxAndroidA2LongHair.Checked = (buffer[17] & 8) != 0;
            this.checkBoxAndroidA2ShortHair.Checked = (buffer[17] & 4) != 0;
            int countAndroidRenegade = this.checkBoxAndroid8B.Checked ? 3 : 0;
            int countAndroid = countAndroidRenegade + BitCount.PrecomputedBitcount(buffer[18] & 0x7C) + BitCount.PrecomputedBitcount(buffer[17] & 0x7C);
            this.textProgressBarAndroid.Value = countAndroid;

            this.checkBoxPeculiarCourageousBrother.Checked = (buffer[17] & 2) != 0;
            this.checkBoxPeculiarHatefulSister.Checked = (buffer[17] & 1) != 0;
            this.checkBoxPeculiarVengefulChild.Checked = (buffer[16] & 128) != 0;
            this.checkBoxPeculiarGoldTank.Checked = (buffer[16] & 64) != 0;
            this.checkBoxPeculiarGoldGoliathBiped.Checked = (buffer[16] & 32) != 0;
            this.checkBoxPeculiarGoliathTankDesert.Checked = (buffer[16] & 16) != 0;
            this.checkBoxPeculiarGunmanBiped.Checked = (buffer[16] & 8) != 0;
            this.checkBoxPeculiarGunmanFlyer.Checked = (buffer[16] & 4) != 0;
            this.checkBoxPeculiarGunmanStubby.Checked = (buffer[16] & 2) != 0;
            this.checkBoxPeculiarBlooddrenchedMachine.Checked = (buffer[16] & 1) != 0;
            this.checkBoxPeculiarAmusementParkRabbit.Checked = (buffer[23] & 128) != 0;
            this.checkBoxPeculiarZombieClown.Checked = (buffer[23] & 64) != 0;
            this.checkBoxPeculiarAnimalMachine.Checked = (buffer[23] & 32) != 0;
            this.checkBoxPeculiarGravekeeper.Checked = (buffer[23] & 16) != 0;
            this.checkBoxPeculiarMonsterType.Checked = (buffer[23] & 8) != 0;
            this.checkBoxPeculiarDyingGoliathBiped.Checked = (buffer[23] & 4) != 0;
            int countPeculiar = BitCount.PrecomputedBitcount(buffer[17] & 0x03) + BitCount.PrecomputedBitcount(buffer[16]) + BitCount.PrecomputedBitcount(buffer[23] & 0xFC);
            this.textProgressBarPeculiar.Value = countPeculiar;

            this.checkBoxAmicableMachinewithaDream.Checked = (buffer[23] & 2) != 0;
            this.checkBoxAmicableMachineinLove.Checked = (buffer[23] & 2) != 0;
            this.checkBoxAmicableMachinewithMakeup.Checked = (buffer[23] & 2) != 0;
            this.checkBoxAmicableRomeo.Checked = (buffer[22] & 64) != 0;
            this.checkBoxAmicableJuliet.Checked = (buffer[22] & 64) != 0;
            this.checkBoxAmicableFatherServoWhiteBelt.Checked = (buffer[22] & 16) != 0;
            this.checkBoxAmicableFatherServoBrownBelt.Checked = (buffer[22] & 8) != 0;
            this.checkBoxAmicableFatherServoBlackBelt.Checked = (buffer[22] & 4) != 0;
            this.checkBoxAmicableFatherServoRedandWhiteBelt.Checked = (buffer[22] & 2) != 0;
            this.checkBoxAmicableFatherServoRedBelt.Checked = (buffer[22] & 1) != 0;
            this.checkBoxAmicableAnimallovingMachine.Checked = (buffer[21] & 128) != 0;
            this.checkBoxAmicableHighspeedMachine.Checked = (buffer[9] & 64) != 0;
            this.checkBoxAmicableMasamune.Checked = (buffer[21] & 64) != 0;
            int countSarteFangirls = this.checkBoxAmicableMachinewithaDream.Checked ? 3 : 0;
            int countShakespeare = this.checkBoxAmicableJuliet.Checked ? 2 : 0;
            int countAmicable = countSarteFangirls + countShakespeare + BitCount.PrecomputedBitcount(buffer[22] & 0x1F) + BitCount.PrecomputedBitcount(buffer[21] & 0xC0) + BitCount.PrecomputedBitcount(buffer[9] & 0x40);
            this.textProgressBarAmicable.Value = countAmicable;

            this.checkBoxEmilEmil.Checked = (buffer[21] & 32) != 0;
            this.checkBoxEmilEmilClonesFlying.Checked = (buffer[21] & 16) != 0;
            this.checkBoxEmilEmilClonesGround.Checked = (buffer[21] & 16) != 0;
            int countEmil = BitCount.PrecomputedBitcount(buffer[21] & 0x20) + (this.checkBoxEmilEmilClonesFlying.Checked ? 2 : 0);
            this.textProgressBarEmil.Value = countEmil;
            
            this.textProgressBarUnit.Value = countStd + countDesert + countPark + countForest + countFactory + countVillage + countEnhanced + countEMP + countSpecial + countAndroid + countPeculiar + countAmicable + countEmil;

#if DEBUG
            this.debugValue2.Text = string.Join(", ", buffer);
#endif
        }

        public void updateEndings(string phaseName, string phaseNameOld)
        {
            Debug.WriteLine("[NierIntelTracker] phase name change: " + phaseNameOld + " -> " + phaseName);

            switch (phaseName)
            {
                case "EndRoll_A":
                    this.checkBoxEndingA.Checked = true;
                    break;
                case "BackTitle_B":
                    this.checkBoxEndingB.Checked = true;
                    break;
                case "EndRoll_CD":
                    if (phaseNameOld.Equals("345_D_Tower_A2win_9Shack"))
                    {
                        this.checkBoxEndingC.Checked = true;
                    }
                    if (phaseNameOld.Equals("340_C_Tower_9Swin"))
                    {
                        this.checkBoxEndingD.Checked = true;
                    }
                    break;
                case "start":
                    if (this.checkBoxEndingC.Checked || phaseNameOld.Equals("340_C_Tower_9Swin"))
                    {
                        this.checkBoxEndingD.Checked = true;
                    }
                    else if (this.checkBoxEndingD.Checked || phaseNameOld.Equals("345_D_Tower_A2win_9Shack"))
                    {
                        this.checkBoxEndingC.Checked = true;
                    }
                    break;
                case "BackTitle_FIN":
                    this.checkBoxEndingE.Checked = true;
                    break;
                case "Ending_F":
                    this.checkBoxEndingF.Checked = true;
                    break;
                case "Ending_G":
                    this.checkBoxEndingG.Checked = true;
                    break;
                case "Ending_H":
                    this.checkBoxEndingH.Checked = true;
                    break;
                case "Ending_I":
                    this.checkBoxEndingI.Checked = true;
                    break;
                case "Ending_J":
                    this.checkBoxEndingJ.Checked = true;
                    break;
                case "Ending_K":
                    this.checkBoxEndingK.Checked = true;
                    break;
                case "Ending_L":
                    this.checkBoxEndingL.Checked = true;
                    break;
                case "Ending_M":
                    this.checkBoxEndingM.Checked = true;
                    break;
                case "Ending_N":
                    this.checkBoxEndingN.Checked = true;
                    break;
                case "Ending_O":
                    this.checkBoxEndingO.Checked = true;
                    break;
                case "Ending_P":
                    this.checkBoxEndingP.Checked = true;
                    break;
                case "Ending_Q":
                    this.checkBoxEndingQ.Checked = true;
                    break;
                case "Ending_R":
                    this.checkBoxEndingR.Checked = true;
                    break;
                case "Ending_S":
                    this.checkBoxEndingS.Checked = true;
                    break;
                case "Ending_T":
                    this.checkBoxEndingT.Checked = true;
                    break;
                case "Ending_U":
                    this.checkBoxEndingU.Checked = true;
                    break;
                case "Ending_V":
                    this.checkBoxEndingV.Checked = true;
                    break;
                case "Ending_W":
                    this.checkBoxEndingW.Checked = true;
                    break;
                case "Ending_X":
                    this.checkBoxEndingX.Checked = true;
                    break;
                case "Ending_Y":
                    this.checkBoxEndingY.Checked = true;
                    break;
                case "Ending_Z":
                    this.checkBoxEndingZ.Checked = true;
                    break;
                default:
                    Debug.WriteLine("[NierIntelTracker] phase name skipped: " + phaseName);
                    break;
            }

            updateEndingCount();
        }

        public void updateEndingCount()
        {
            this.textProgressBarEndings.Value = Convert.ToInt32(this.checkBoxEndingA.Checked)
                + Convert.ToInt32(this.checkBoxEndingB.Checked)
                + Convert.ToInt32(this.checkBoxEndingC.Checked)
                + Convert.ToInt32(this.checkBoxEndingD.Checked)
                + Convert.ToInt32(this.checkBoxEndingE.Checked)
                + Convert.ToInt32(this.checkBoxEndingF.Checked)
                + Convert.ToInt32(this.checkBoxEndingG.Checked)
                + Convert.ToInt32(this.checkBoxEndingH.Checked)
                + Convert.ToInt32(this.checkBoxEndingI.Checked)
                + Convert.ToInt32(this.checkBoxEndingJ.Checked)
                + Convert.ToInt32(this.checkBoxEndingK.Checked)
                + Convert.ToInt32(this.checkBoxEndingL.Checked)
                + Convert.ToInt32(this.checkBoxEndingM.Checked)
                + Convert.ToInt32(this.checkBoxEndingN.Checked)
                + Convert.ToInt32(this.checkBoxEndingO.Checked)
                + Convert.ToInt32(this.checkBoxEndingP.Checked)
                + Convert.ToInt32(this.checkBoxEndingQ.Checked)
                + Convert.ToInt32(this.checkBoxEndingR.Checked)
                + Convert.ToInt32(this.checkBoxEndingS.Checked)
                + Convert.ToInt32(this.checkBoxEndingT.Checked)
                + Convert.ToInt32(this.checkBoxEndingU.Checked)
                + Convert.ToInt32(this.checkBoxEndingV.Checked)
                + Convert.ToInt32(this.checkBoxEndingW.Checked)
                + Convert.ToInt32(this.checkBoxEndingX.Checked)
                + Convert.ToInt32(this.checkBoxEndingY.Checked)
                + Convert.ToInt32(this.checkBoxEndingZ.Checked);
        }

        public void updateComponentDisplayStatus(string status)
        {
            this.labelConnectionStatus.Text = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.checkBoxEndingA.Checked = false;
            this.checkBoxEndingB.Checked = false;
            this.checkBoxEndingC.Checked = false;
            this.checkBoxEndingD.Checked = false;
            this.checkBoxEndingE.Checked = false;
            this.checkBoxEndingF.Checked = false;
            this.checkBoxEndingG.Checked = false;
            this.checkBoxEndingH.Checked = false;
            this.checkBoxEndingI.Checked = false;
            this.checkBoxEndingJ.Checked = false;
            this.checkBoxEndingK.Checked = false;
            this.checkBoxEndingL.Checked = false;
            this.checkBoxEndingM.Checked = false;
            this.checkBoxEndingN.Checked = false;
            this.checkBoxEndingO.Checked = false;
            this.checkBoxEndingP.Checked = false;
            this.checkBoxEndingQ.Checked = false;
            this.checkBoxEndingR.Checked = false;
            this.checkBoxEndingS.Checked = false;
            this.checkBoxEndingT.Checked = false;
            this.checkBoxEndingU.Checked = false;
            this.checkBoxEndingV.Checked = false;
            this.checkBoxEndingW.Checked = false;
            this.checkBoxEndingX.Checked = false;
            this.checkBoxEndingY.Checked = false;
            this.checkBoxEndingZ.Checked = false;
            this.textProgressBarEndings.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.checkBoxEndingA.Checked = true;
            this.checkBoxEndingB.Checked = true;
            this.checkBoxEndingC.Checked = true;
            this.checkBoxEndingD.Checked = true;
            this.checkBoxEndingE.Checked = true;
            this.checkBoxEndingF.Checked = true;
            this.checkBoxEndingG.Checked = true;
            this.checkBoxEndingH.Checked = true;
            this.checkBoxEndingI.Checked = true;
            this.checkBoxEndingJ.Checked = true;
            this.checkBoxEndingK.Checked = true;
            this.checkBoxEndingL.Checked = true;
            this.checkBoxEndingM.Checked = true;
            this.checkBoxEndingN.Checked = true;
            this.checkBoxEndingO.Checked = true;
            this.checkBoxEndingP.Checked = true;
            this.checkBoxEndingQ.Checked = true;
            this.checkBoxEndingR.Checked = true;
            this.checkBoxEndingS.Checked = true;
            this.checkBoxEndingT.Checked = true;
            this.checkBoxEndingU.Checked = true;
            this.checkBoxEndingV.Checked = true;
            this.checkBoxEndingW.Checked = true;
            this.checkBoxEndingX.Checked = true;
            this.checkBoxEndingY.Checked = true;
            this.checkBoxEndingZ.Checked = true;
            this.textProgressBarEndings.Value = 26;
        }

        private void manualEndingChanged(object sender, EventArgs e)
        {
            updateEndingCount();
        }
    }
}
