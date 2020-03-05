 /* * * * * *
 * Author: Quoc Nguyen
 * Email: ntq.quoc@gmail.com
 * * * * * */

using System;
using Quocnt.SimpleJSON;
using UnityEngine;

namespace Localization.Extension
{
	public enum LocalizedTextKey
	{
			PREPARE_ATTACK_0,		//Available loot:
			PREPARE_ATTACK_1,		//Defeat:
			PREPARE_ATTACK_2,		//Battle starts in:
			PREPARE_ATTACK_3,		//Hold both sides to start attacking
			PREPARE_ATTACK_4,		//End Battle
			PREPARE_ATTACK_5,		//Next
			PREPARE_ATTACK_6,		//ENGAGE
			BASE_BATTLE_2,		//Battle starts
			BASE_BATTLE_3,		//Surrender
			BASE_BATTLE_4,		//Overall Damage
			WARN_OUT_RANGE_BATTLE_BASE,		//Battle will end if you don’t resume attacking in time.
			OPPONENT_SHIELD_ACTIVATED,		//Opponent’s shield is activated for {0}
			SEARCH_ENEMY_0,		//Return Home
			SEARCH_ENEMY_1,		//Search for opponents…
			ATTACK_BUTTON,		//Attack!
			SHOP_BUTTON,		//Shop
			EQUIP_BUTTON,		//Equip
			EQUIPPED_TXT,		//Equipped
			ALREADY_EQUIPPED_TXT,		//Already Equipped
			RECOVER_BUTTON,		//Recover
			SETTINGS_BUTTON,		//Settings
			STORAGE_HOME_BUTTON,		//Storage
			FINISH_NOW,		//Finish now
			FINISH_NOW_DESC,		//Do you want to finish the upgrade of {0}?
			FINISH_NOW_TITLE,		//Finish now!
			CANCEL_BUTTON,		//Cancel
			OKAY_BUTTON,		//OK
			ENTER_SHOP_TXT,		//Buy more
			FULL_CAPACITY_WARNING,		//Upgrade the ARK to store more resources.
			INFOR_BUTTON,		//Info
			UPGRADE_BUTTON,		//Upgrade
			STORAGE_BUTTON,		//Storage
			STORAGE_TITLE,		//Storage
			COLLECT_BUTTON,		//Collect
			BOOST,		//Boost
			BOOST_ALL,		//Boost all
			BOOST_PANEL_TITLE,		//Boost production!
			BOOST_PANEL_TEXT,		//Double the production for {0}h?
			D_BOOST_PANEL_TEXT,		//Double the production of all collector of this type for {0}h?
			INFOR_PRODUCTION_TEXT,		//Production rate/hour:
			STORAGE_CAPACITY,		//Capacity: {0}
			INFOR_HP,		//Hitpoints: 
			INFOR_CAPACITY,		//Capacity: 
			INFOR_REDUCE_DMG,		//Damage Reduction:
			INFOR_DPS,		//Damage / sec: 
			INFOR_HEAL,		//Heal/sec: 
			INFOR_DMG,		//Damage / bullet: 
			INFOR_MAXDEPLOY,		//Max Deploy:
			INFOR_UNITSIZE,		//Unit size: 
			INFOR_MOVESPEED,		//Movement speed: 
			INFOR_COOLDOWN,		//Cool down: 
			INFOR_RANGE,		//Range:
			INFOR_DURATION,		//Duration:
			INFOR_FAVORITE_TARGET,		//Priority:
			INFOR_FIRERATE,		//Fire rate:
			INFOR_PRIMARY_SLOT,		//Primary slots:
			INFOR_SPECIAL_SLOT,		//Special slots:
			INFOR_SLOTS,		//Weapon slots:
			INFOR_TIME_ACTIVE,		//Active time:
			INFOR_TITLE_UNIT_STATS,		//UNIT STATS
			INFOR_WP_PRIMARY,		//Primary
			INFOR_WP_SPECIAL,		//Special
			INFOR_TRACKING,		//Tracking Duration:
			INFOR_TIME_STUN,		//Time Stun:
			INFOR_INVEN,		//Inventory: {0}
			INFOR_CRIT_DMG,		//Crit damage: 
			INFOR_CRIT_CHANCE,		//Crit chance: 
			BUIDLING_NAME_LEVEL,		//{0} (level {1})
			LEVEL_TITLE,		//Level {0}
			RANGE_DESC,		//Range:
			TILE_DESC,		//{0} tiles
			NEW_DESC,		//New
			NONE_TITLE,		//None
			MISSING_BUILDER_PANEL_TITLE,		//All droids are busy!
			MISSING_BUILDER_PANEL_TEXT,		//Complete the previous building and free up a droid
			MISSING_GOLD_PANEL,		//You need more Gold
			MISSING_GOLD_PANEL_TEXT,		//Buy the missing {0} Gold?
			MISSING_FUEL_PANEL,		//You need more Hyper Fuel
			MISSING_FUEL_PANEL_TEXT,		//Buy the missing {0} Hyper Fuel?
			MISSING_RES_PANEL,		//You need more Resource
			MISSING_RES_PANEL_TEXT,		//Buy the missing {0} Gold & {1} Hyper Fuel?
			MISSING_GEM_PANEL,		//Not enough gems
			MISSING_GEM_FOR_NEXT_FIND,		//You don’t have enough gems!
			MISSING_GEM_PANEL_TEXT,		//Do you want to get more?
			CANCEL_PANEL,		//Stop upgrade?
			CANCEL_PANEL_TEXT,		//Do you really want to stop upgrading {0}? Only 50% of the cost will be refunded
			WARN_UPGRADE_IN_BOOST_TIME_TITLE,		//End boost?
			WARN_UPGRADE_IN_BOOST_TIME,		//Upgrading the building will end the boost. Are you sure?
			UPGRADE_TITLE_LOCK,		//Upgrade Locked
			WARN_REQUIRE_TEXT,		//Require buildings:
			WARN_UPGRADE_RED_TITLE,		//Note!
			WARN_UPGRADE_BUILDING,		//Contruct the following buildings to unlock the next ARK level!
			UPGRADE_TIME_TEXT,		//Upgrade time
			UPGRADE_PANEL_TITLE,		//Upgrade to level {0}?
			UPGRADE_UNLOCK,		//Unlocks buildings:
			REMOVE_OBS_TITLE,		//Remove Obstacle
			REMOVE_OBS_DESC,		//Do you really want to remove {0}?
			REMOVE_NOW_TITLE,		//Remove now
			REMOVE_NOW_DESC,		//Do you want to remove now {0}
			SHOP,		//Shop
			TREASURE_TAB,		//Treasures
			RESOURCES_TAB,		//Resources
			DEFENSES_TAB,		//Defenses
			SHIELD_TAB,		//Shield
			WARN_UPGRADE_PANEL,		//You need to upgrade your {0} to level {1}!
			WARN_UPGRADE_TO_BUILD_TEXT,		//Upgrade {0} to level {1} to build more!
			WARN_BUILD_MAX_ALREADY_TEXT,		//You’ve already built the maximum amount of these buildings.
			WARN_UPGRADE_TO_UNLOCK_TEXT,		//Upgrade {0} to level {1} to unlock!
			WARN_UPGRADE_LV,		//Level {0} {1} Required
			EQUIP_BUTTON_BACK_TEXT,		//Back
			EQUIP_BODY_BUTTON_TEXT,		//Bodies
			EQUIP_WING_BUTTON_TEXT,		//Wings
			EQUIP_INFOR_INVENTORY,		//Inventory
			EQUIPMENT_BUTTON,		//Equip
			UNLOCK_BUTTON,		//Unlock
			EDIT_BUTTON,		//Edit
			VICTORY_TEXT,		//Victory
			DRAW_TEXT,		//Draw
			DEFEAT_TEXT,		//Defeat
			SHIP_ACTIVE_TXT,		//Currently active
			TOTALDAME_RESULT_TEXT,		//Total damage:
			YOUGOT_TEXT,		//You got:
			OWNED_MODULE_TEXT,		//You owned this Module.
			RECOVERY_TITLE,		//Recovery Status
			RECOVERY_TIME,		//Full in {0}
			RECOVERY_FINISH_BUTTON_DESC,		//Finish recovery:
			RECOVERY_FINISH_NOW_TEXT,		//Do you want to finish the recovery process?
			RECOVERY_BOOST_TITLE,		//Boost Recovery!
			RECOVERY_BOOST_TEXT,		//Boost the recovery process by 2x for 1h?
			FINDMATCH_SINGLE,		//Single Player
			FINDMATCH_ADVENTURE_TEXT,		//Adventure Mode
			FINDMATCH_ADVENTURE_GUIDE_TEXT,		//Tap to explore
			FINDMATCH_AVAILABLE_MATS,		//Available materials
			FINDMATCH_MULTI,		//Multiplayer
			FINDMATCH_TROPHY,		//Your trophies:
			FINDMATCH_BUTTON,		//Find a Match
			FINDMATCH_ATTACK_COST,		//Attack cost:
			WARNING_MISSING_BUILD_TITLE,		//Warning
			WARNING_MISSING_BUILD_TEXT,		//You need to build {0}!
			NOTIFY_ATK_TITLE,		//Chief, our base was attacked!
			NOTIFY_ATK_HEADER,		//Enemy Raid
			NOTIFY_ATK_DESC,		//Your base was attacked while you were gone!
			NOTIFY_ATK_SCORE_TEXT,		//Score
			NOTIFY_ATK_LOG,		//Attack Log
			NOTIFY_DEF_LOG,		//Defense Log
			NOTIFY_SHARE_BTN,		//Share
			NOTIFY_REPLAY_BTN,		//Replay
			NOTIFY_REVENGE_BTN,		//Revenge
			NOTIFY_ATK_LOST,		//You Lost
			NOTIFY_ATK_WON,		//You Won
			NOTIFY_REPLAY_NOT_AVAILABLE,		//Replay not available
			NOTIFY_DEF_WON,		//You Defense Won
			NOTIFY_DEF_LOST,		//You Defense Lost
			YES_BTN,		//Yes
			NO_BTN,		//Later
			CONFIRM_BUY_BUILDER_TITLE,		//Purchase Builder
			CONFIRM_BUY_BUILDER_DESC,		//Do you want to buy extra builder?
			WARN_LOW_HP,		//Low HP
			PICK_USERNAME_TITLE,		//My name is…
			PICK_USERNAME_DESC,		//You can change your name later
			CHANGE_USERNAME_TITLE,		//Change name
			CHANGE_USERNAME_DESC,		//You only get one FREE name change – use it wisely as future name changes cost Gems.
			VIEW_INFO_BTN,		//View Info
			TROPHY_RANK_TITLE,		//RANKING
			TROPHY_RANK_TOP_PLAYERS,		//Top Players
			RANK_GIFT_FULL_TITLE,		//Storage Full
			RANK_GIFT_FULL_DESC,		//The storage is full, please spare some space to claim the rewards.
			CLAIM_BTN,		//Claim
			DRONE_NAME,		//Builder Drone
			GOLD_NAME,		//Gold
			FUEL_NAME,		//Hyper Fuel
			GEM_NAME,		//Gem
			GUN_LIGHT_1A_NAME,		//Pulse Laser
			GUN_LIGHT_1A_DESC,		//Classic weapon, fire heated laser bolt with lightning speed.
			GUN_LIGHT_1B_NAME,		//Quantum Beam
			GUN_LIGHT_1B_DESC,		//Advance weapon generates quantum beams that strike through all targets in line.
			GUN_LIGHT_1C_NAME,		//Helix Cannon
			GUN_LIGHT_1C_DESC,		//High class firearms, unleased missiles barrage in quick succession.
			GUN_LIGHT_1D_NAME,		//Lightning Conduit
			GUN_LIGHT_1D_DESC,		//Deals ridiculously low damage, but stuns the target with remarkable time.
			GUN_LIGHT_1E_NAME,		//Starfire Blast
			GUN_LIGHT_1E_DESC,		//Firing plasma bullets in a cone, ideal damage for close range fighter.
			GUN_HEAVY_1A_NAME,		//Hydra Cannon
			GUN_HEAVY_1A_DESC,		//Rains down a barrage of homing missiles.
			GUN_HEAVY_1B_NAME,		//Photon Array
			GUN_HEAVY_1B_DESC,		//Focus energy to pierces through all targets in line.
			GUN_HEAVY_1C_NAME,		//Kinsectoid Lair
			GUN_HEAVY_1C_DESC,		//Unleash two wingmen droids to fight along the ship.
			GUN_HEAVY_1D_NAME,		//Space Furnace
			GUN_HEAVY_1D_DESC,		//Bombard the ground below with devastating damage.
			GUN_HEAVY_1E_NAME,		//Ethereal Vortex
			GUN_HEAVY_1E_DESC,		//Turn the ship into invulnerable state for a short period.
			TROOP_MARINE_NAME,		//Marine
			TROOP_MARINE_DESC,		//Able to deal significant damage if well-protected. The Marine are fearsome when come in large numbers.
			TROOP_TANK_NAME,		//Mini Tank
			TROOP_TANK_DESC,		//Light armored unit with enough damage to wreaks havoc.
			TROOP_CHOPPER_NAME,		//Chopper
			TROOP_CHOPPER_DESC,		//High speed flying unit which can penetrates enemy defense lines and rain down missiles.
			TROOP_HEAL_DRONE_NAME,		//Medic Drone
			TROOP_HEAL_DRONE_DESC,		//Life saver on the battlefield. War is dangerous so they use machine to do the job.
			TROOP_BULLDOZER_NAME,		//Demolisher
			TROOP_BULLDOZER_DESC,		//Slow and steady, this big boy can take down a city entirely if leaving alone.
			TROOP_FLAMER_NAME,		//Scorcher
			TROOP_FLAMER_DESC,		//Firing a volley of flames, designed to take down multiple adjacent structures.
			TROOP_B52_NAME,		//Oppressor
			TROOP_B52_DESC,		//A truly flying fortress, designed to attract damage from air-to-air defense.
			TROOP_BOMB_NAME,		//Bomber Droid
			TROOP_BOMB_DESC,		//A suicide unit, deals massive damage to buildings.
			TROOP_COLOSSUS_NAME,		//Colossus
			TROOP_COLOSSUS_DESC,		//Flying unit with blasting punch!\nDeal <color=green>TRIPLE DAMAGE</color> to resources buildings!
			TALENT_LIGHT_WEAPON_ATK_SPD_NAME,		//Rapid Fire
			TALENT_LIGHT_WEAPON_ATK_SPD_DESC,		//Increase all Primary weapons firing rate.
			TALENT_TROOP_MARINE_QUANTITY_NAME,		//Marine Legion
			TALENT_TROOP_MARINE_QUANTITY_DESC,		//Increase Marine quantity.
			TALENT_TROOP_TANK_DMG_NAME,		//Metal Power
			TALENT_TROOP_TANK_DMG_DESC,		//Increase Siege Tank damage.
			TALENT_LIGHT_DMG_NAME,		//Rising Force
			TALENT_LIGHT_DMG_DESC,		//Increase all Primary weapons damage.
			TALENT_LIGHT_CRIT_CHANCE_NAME,		//Focus Fire
			TALENT_LIGHT_CRIT_CHANCE_DESC,		//Increase all Primary weapons critical chance.
			TALENT_HEAVY_COOL_DOWN_NAME,		//Quick Gears
			TALENT_HEAVY_COOL_DOWN_DESC,		//Reduce all Special weapons cool down.
			TALENT_SHIP_HP_UP_NAME,		//Adamanskin
			TALENT_SHIP_HP_UP_DESC,		//Increase all Ships hitpoints.
			TALENT_TROOP_HEAL_DRONE_SPD_NAME,		//Rush Hour
			TALENT_TROOP_HEAL_DRONE_SPD_DESC,		//Increase Medic Drone movement speed.
			TALENT_TROOP_FLAMER_HP_NAME,		//Galaxy Heat
			TALENT_TROOP_FLAMER_HP_DESC,		//Increase Scorcher hitpoints.
			TALENT_LIGHT_CRIT_DMG_NAME,		//Ardent Shot
			TALENT_LIGHT_CRIT_DMG_DESC,		//Increase all Primary weapons critical damage.
			TALENT_HEAVY_DMG_NAME,		//Ultimate Power
			TALENT_HEAVY_DMG_DESC,		//Increase all Special weapons power.
			TALENT_TROOP_RAMBO_REGEN_NAME,		//Super Serum
			TALENT_TROOP_RAMBO_REGEN_DESC,		//Colossus regenerate hitpoints over time.
			TALENT_TROOP_BULLDOZER_SPD_NAME,		//Raging Bull
			TALENT_TROOP_BULLDOZER_SPD_DESC,		//Increase Demolisher movement speed.
			TALENT_TROOP_CHOPPER_DMG_NAME,		//Hawk Eye
			TALENT_TROOP_CHOPPER_DMG_DESC,		//Increase Chopper damage.
			TALENT_TROOP_COLOSSUS_HP_NAME,		//Super Serum
			TALENT_TROOP_COLOSSUS_HP_DESC,		//Increase Colossus hitpoints.
			TALENT_TROOPS_DMG_NAME,		//Elite Army
			TALENT_TROOPS_DMG_DESC,		//Increase all troops damage.
			TALENT_TROOPS_HP_NAME,		//Tough Guns
			TALENT_TROOPS_HP_DESC,		//Increase all troops hitpoints.
			TALENT_ARK_HP_NAME,		//Galaxy Fortress
			TALENT_ARK_HP_DESC,		//Increase the ARK hitpoints.
			TALENT_TROOP_TANK_HP_NAME,		//Metal Gear
			TALENT_TROOP_TANK_HP_DESC,		//Increase Mini Tank hitpoints.
			TALENT_BUILDING_MINE_PROD_RATE_NAME,		//Overtime
			TALENT_BUILDING_MINE_PROD_RATE_DESC,		//Increase Gold and Hyer Fuel production.
			TALENT_BUILDING_MINE_HP_NAME,		//Trusted Bank
			TALENT_BUILDING_MINE_HP_DESC,		//Increase Gold Mine and Hyper Fuel Pump hitpoints.
			TALENT_TURRET_MINI_DMG_NAME,		//Serious Shot
			TALENT_TURRET_MINI_DMG_DESC,		//Increase Mini Turret damage.
			TALENT_TURRET_MISSILE_TRACK_TIME_NAME,		//Homing Guidance
			TALENT_TURRET_MISSILE_TRACK_TIME_DESC,		//Increase Missile Turret tracking duration.
			TALENT_TURRET_FIRE_BURN_DMG_NAME,		//Turret Fire Burn
			TALENT_TURRET_FIRE_BURN_DMG_DESC,		//Increase Turret Fire damage burn per sec.
			TALENT_TURRET_PHOTON_HP_NAME,		//Photon Heal
			TALENT_TURRET_PHOTON_HP_DESC,		//Increase Turret Photon HP.
			TALENT_TURRET_THUNDER_CHAIN_NAME,		//Thunder Chain
			TALENT_TURRET_THUNDER_CHAIN_DESC,		//Increase Turret Thunder chain.
			TALENT_BUILDING_MINE_BOMB_DMG_NAME,		//Bigger Bombs
			TALENT_BUILDING_MINE_BOMB_DMG_DESC,		//Increase Land Mine damage.
			TALENT_TURRET_FIRE_HP_NAME,		//Heat Shield
			TALENT_TURRET_FIRE_HP_DESC,		//Increase Flamethrower hitpoints.
			TALENT_TURRET_PHOTON_ATK_SPD_NAME,		//Quantum Break
			TALENT_TURRET_PHOTON_ATK_SPD_DESC,		//Increase Photon Cannon fire rate.
			TALENT_TURRET_THUNDER_STUN_TIME_NAME,		//Thundergod
			TALENT_TURRET_THUNDER_STUN_TIME_DESC,		//Increase Bolt Caster stun duration.
			TALENT_BUILDING_SHIELD_GENERATOR_HP_NAME,		//Enhance Shield
			TALENT_BUILDING_SHIELD_GENERATOR_HP_DESC,		//Increase Shield Generator hitpoints.
			TALENT_HQ_DMG_NAME,		//ARK Power
			TALENT_HQ_DMG_DESC,		//Increase ARK damage
			TALENT_HQ_HP_NAME,		//ARK HP
			TALENT_HQ_HP_DESC,		//Increase ARK hp
			TALENT_TROOP_TANK_MAX_DEPLOY_NAME,		//Mini Tank Augmentation
			TALENT_TROOP_TANK_MAX_DEPLOY_DESC,		//Increase Mini Tank Max Deploy.
			TALENT_TROOP_MARINE_MAX_DEPLOY_NAME,		//Marine Augmentation
			TALENT_TROOP_MARINE_MAX_DEPLOY_DESC,		//Increase Marine Max Deploy.
			TALENT_TROOP_COLOSSUS_MAX_DEPLOY_NAME,		//Colossus Augmentation
			TALENT_TROOP_COLOSSUS_MAX_DEPLOY_DESC,		//Increase Colossus Max Deploy.
			TALENT_TROOP_BULLDOZER_MAX_DEPLOY_NAME,		//Bulldozer Augmentation
			TALENT_TROOP_BULLDOZER_MAX_DEPLOY_DESC,		//Increase Bulldozer Max Deploy.
			TALENT_TROOP_HEAL_DRONE_MAX_DEPLOY_NAME,		//Medic Drone Augmentation
			TALENT_TROOP_HEAL_DRONE_MAX_DEPLOY_DESC,		//Increase Medic Drone Max Deploy.
			TALENT_TROOP_CHOPPER_MAX_DEPLOY_NAME,		//Chopper Augmentation
			TALENT_TROOP_CHOPPER_MAX_DEPLOY_DESC,		//Increase Chopper Max Deploy.
			TALENT_TROOP_SPIDER_BOMB_MAX_DEPLOY_NAME,		//Bomber Droid Augmentation
			TALENT_TROOP_SPIDER_BOMB_MAX_DEPLOY_DESC,		//Increase Bomber Droid Max Deploy.
			SHIP_NORMAL_1A_NAME,		//Falcon MK-1
			SHIP_NORMAL_1A_DESC,		//A versatile combat ship with balance firearms and hitpoints.
			SHIP_NORMAL_1B_NAME,		//Falcon MK-2
			SHIP_NORMAL_1B_DESC,		//A versatile combat ship with balance firearms and hitpoints.
			SHIP_NORMAL_1C_NAME,		//Falcon MK-3
			SHIP_NORMAL_1C_DESC,		//A versatile combat ship with balance firearms and hitpoints.
			SHIP_LIGHT_1A_NAME,		//Phoenix MK-1
			SHIP_LIGHT_1A_DESC,		//Light weight class with extra weapon slots but has ridiculous low hitpoints.
			SHIP_LIGHT_1B_NAME,		//Phoenix MK-2
			SHIP_LIGHT_1B_DESC,		//Light weight class with extra weapon slots but has ridiculous low hitpoints.
			SHIP_LIGHT_1C_NAME,		//Phoenix MK-3
			SHIP_LIGHT_1C_DESC,		//Light weight class with extra weapon slots but has ridiculous low hitpoints.
			SHIP_HEAVY_1A_NAME,		//Hammer MK-1
			SHIP_HEAVY_1A_DESC,		//Heavy weight battleship, sacrifice firepower for hull hitpoints.
			SHIP_HEAVY_1B_NAME,		//Hammer MK-2
			SHIP_HEAVY_1B_DESC,		//Heavy weight battleship, sacrifice firepower for hull hitpoints.
			SHIP_HEAVY_1C_NAME,		//Hammer MK-3
			SHIP_HEAVY_1C_DESC,		//Heavy weight battleship, sacrifice firepower for hull hitpoints.
			IN_BATTLE_OUT_OF_BOUND,		//Return to battle!
			IN_BATTLE_CANT_DEPLOY,		//Cannot deploy troops here!
			IN_BATTLE_END_TIME,		//Battle ends in:
			TIP_LOADING_1,		//Tip: Closest enemy will be targeted automatically.
			TIP_LOADING_2,		//Tip: Attacking enemies charges up your Special Ability.
			TIP_LOADING_3,		//Tip: Purchase more Builder Droids to speed up your buildings construction.
			TIP_LOADING_4,		//Tip: You'll get a free shield after being defeated.
			TIP_LOADING_5,		//Tip: Watch replays to improve your defense and attack strategy.
			TIP_LOADING_6,		//Tip: Upgrade your weapons and army to have advantages in battle.
			TUT_PHASE_1_TXT_1,		//Welcome to the combat flight simulator, newbie pilot!
			TUT_PHASE_1_TXT_2,		//<color=#FF1818>HOLD</color> the <color=#FF1818>RED CONTROL</color> to attack.\nClosest enemy will be targeted automatically!
			TUT_PHASE_1_TXT_3,		//Good job, attacking enemies charges up your Special Ability.
			TUT_PHASE_1_TXT_4,		//<color=#FF9900>YELLOW CONTROL</color> the <color=#FF9900>YELLOW CONTROL</color> to aim your Special weapon, release to fire!
			TUT_PHASE_1_TXT_5,		//Cool, now move to next area and deliver havoc!
			TUT_PHASE_1_TXT_6,		//<color=#004BFF>DRAG</color> the <color=#004BFF>BLUE CONTROL</color> to move your ship to the highlighted area.
			TUT_PHASE_1_TXT_7,		//Your aiming is automatically, just <color=#FF1818>HOLD</color> the <color=#FF1818>RED CONTROL</color>!
			TUT_PHASE_1_TXT_8,		//Don't forget to use your Special Ability.
			TUT_PHASE_1_TXT_9,		//Well done, you're definitely the top gun in the galaxy, potentially!
			TUT_PHASE_1_TXT_10,		//HOLD YOUR DEVICE LIKE THIS
			TUT_PHASE_2_TXT_1,		//Looks like you know how to control your ship! But you'll need more power before go to the real battle!
			TUT_PHASE_2_TXT_2,		//Now let's setup your army before going to the real battle!
			TUT_PHASE_3_TXT_1,		//This is a rival base, destroy their ARK to achieve victory!
			TUT_PHASE_3_TXT_2,		//Summon ally troops to have advantage in battle!
			TUT_PHASE_4_TXT_1,		//Let's upgrade our base with the resources you've just looted.
			TUT_PHASE_4_TXT_2,		//Hyper Fuel is essential for research new techs and upgrade your battle power.
			TUT_PHASE_4_TXT_3,		//Now place some defense to protect your base while you're away.
			TUT_PHASE_4_TXT_4,		//Awesome, don't stop the shooting spree! Remember, the best defense is a good offense!
			TUT_PHASE_4_TXT_5,		//You have enough resource to upgrade the ARK.
			TUT_PHASE_4_TXT_6,		//Red alert! Hostile is coming, let's see how our defense works!
			TUT_PHASE_4_TXT_7,		//Phew! Next time won't be easy, don't forget to check your defense before going AFK!
			TUT_PHASE_6_TXT_1,		//You have a new unit, let's try it in battle
			TUT_TXT_TAP_CONTINUE,		//(Tap to continue)
			TUT_TXT_WARNING,		//Please complete the tutorial.
			BUILDING_HEAD_QUARTER_NAME,		//Ark
			BUILDING_GOLD_MINE_NAME,		//Gold Mine
			BUILDING_HYPER_FUEL_NAME,		//Hyper Fuel Pump
			BUILDING_BUILDER_CAMP_NAME,		//Builder Droid
			BUILDING_MINI_GUN_NAME,		//Mini Turret
			BUILDING_LASER_TOWER_NAME,		//Laser Cannon
			BUILDING_LASER_BEAM_NAME,		//Photon Cannon
			BUILDING_THUNDER_TURRET_NAME,		//Bolt Caster
			BUILDING_FLAME_TURRET_NAME,		//Flame Thrower
			BUILDING_MISSILE_TOWER_NAME,		//Missile Turret
			BUILDING_SHIELD_GENERATOR_NAME,		//Shield Generator
			BUILDING_MINE_BOMB_NAME,		//Land Mine
			BUILDING_HEAD_QUARTER_DESC,		//The heart of your base, protect it well! Upgrading the Ark to unlock new techs, buildings, troops and more!
			BUILDING_GOLD_MINE_DESC,		//Produces gold used for most buildings construction. Upgrade to increase production rate.
			BUILDING_HYPER_FUEL_DESC,		//Special device to pump up Hyper Fuel used for techs research. Upgrade to increase production rate.
			BUILDING_BUILDER_CAMP_DESC,		//Help you construct buildings. You can buy more builders to construct multiple buildings at once.
			BUILDING_MINI_GUN_DESC,		//Mini Turrets keep your enemy at border. They work well when stick together.
			BUILDING_LASER_TOWER_DESC,		//Laser Cannon is equipped high energy device designed to shoot heavy bolts at its target.
			BUILDING_LASER_BEAM_DESC,		//Photon Cannon is deadly against starship. Watch out for the aiming beam!
			BUILDING_THUNDER_TURRET_DESC,		//Casts bolt of lightning that shock the target and prevent it from action for a moment.
			BUILDING_FLAME_TURRET_DESC,		//Flame Thrower releases a line of flames which burns down enemy. Cannot target air units.
			BUILDING_MISSILE_TOWER_DESC,		//Firing a barrage of homing missile, designed to destroy any air units in range. Cannot target ground units.
			BUILDING_SHIELD_GENERATOR_DESC,		//Generate a deflective shield, protecting structures inside from incoming damage until the shield is destroyed.
			BUILDING_MINE_BOMB_DESC,		//Invisible to enemy. Triggered when any ground units get in range. Then, BOOM!
			BUILDING_WALL_NAME,		//Wall
			BUILDING_WALL_DESC,		//Shields buildings from incoming acttack. Best vs ground units.
			SOCIAL_NETWORK_NOT_AVAILABLE_TITLE,		//Universe Megastorm
			SOCIAL_NETWORK_NOT_AVAILABLE_TXT,		//Connection with HQ is unstable. Please try again.
			SOCIAL_REQUEST_TIME_OUT,		//Connection with HQ is unstable. Please try again.
			SOCIAL_NETWORK_NOT_AVAILABLE_BTN,		//Retry
			TXT_CONFIRM_TITLE,		//Confirm
			SOCIAL_CONFLICT_DATA_TITLE,		//Choose a Save Game
			SOCIAL_CONFLICT_DATA_MESS,		//Which save do you want to use?
			SOCIAL_CONFLICT_DATA_CONFTRM_MESS,		//Are you sure to choose this save data?
			SOCIAL_SELECT_CLOUD_DATA,		//On Cloud
			SOCIAL_SELECT_LOCAL_DATA,		//On Device
			SOCIAL_LAST_PLAYED,		//Last played: {0}
			SOCIAL_USE_BUTTON,		//Use
			ACHIEVEMENT_PVP_VICTORY_NAME,		//Conqueror
			ACHIEVEMENT_PVP_GOLD_LOOTED_NAME,		//Gold Rush
			ACHIEVEMENT_PVP_FUEL_LOOTED_NAME,		//Black Gold Stream
			ACHIEVEMENT_PVP_HIGHEST_TROPHY_NAME,		//Top Challenger
			ACHIEVEMENT_PVP_DEFEND_WIN_NAME,		//Unbreakable
			ACHIEVEMENT_BUILDING_HQ_LV_NAME,		//Grow up
			ACHIEVEMENT_BUILDING_GOLD_MINE_LV_NAME,		//Bigger Mine
			ACHIEVEMENT_BUILDING_FUEL_PUMP_LV_NAME,		//Larger Pump
			ACHIEVEMENT_TROOP_LV_NAME,		//Deadly Army
			ACHIEVEMENT_PRIMARY_WEAPON_LV_NAME,		//Guns of Justice
			ACHIEVEMENT_SPECIAL_WEAPON_LV_NAME,		//Maximum Might
			ACHIEVEMENT_TUTORIAL_NAME,		//Trial Passed
			ACHIEVEMENT_LIKE_FAN_PAGE_NAME,		//Fan Support
			ACHIEVEMENT_PVP_GOLD_LOOTED_DESC,		//Loot {0} gold in a Multiplayer battles.
			ACHIEVEMENT_PVP_FUEL_LOOTED_DESC,		//Loot {0} fuel in a Multiplayer battles.
			ACHIEVEMENT_PVP_HIGHEST_TROPHY_DESC,		//Achieve a total of {0} trophies in Multiplayer battles.
			ACHIEVEMENT_PVP_DEFEND_WIN_DESC,		//Successfully defend against {0} attacks.
			ACHIEVEMENT_BUILDING_HQ_LV_DESC,		//Upgrade ARK to level {0}.
			ACHIEVEMENT_BUILDING_GOLD_MINE_LV_DESC,		//Upgrade a Gold Mine to level {0}.
			ACHIEVEMENT_BUILDING_FUEL_PUMP_LV_DESC,		//Upgrade a Hyper Fuel Pump to level {0}.
			ACHIEVEMENT_TROOP_LV_DESC,		//Upgrade any troop unit to level {0}.
			ACHIEVEMENT_PRIMARY_WEAPON_LV_DESC,		//Upgrade any Primary Weapon to level {0}.
			ACHIEVEMENT_SPECIAL_WEAPON_LV_DESC,		//Upgrade any Special Weapon to level {0}.
			ACHIEVEMENT_TUTORIAL_DESC,		//Complete tutorial {0}.
			ACHIEVEMENT_LIKE_FAN_PAGE_DESC,		//Like Ark Rivals fanpage
			ACHIEVEMENT_PVP_VICTORY_DESC,		//Win {0} Multiplayer battles.
			ACHIEVEMENT_DESTROY_WALL_NAME,		//Wall Breaker
			ACHIEVEMENT_DESTROY_WALL_DESC,		//Destroy {0} enemy Walls
			ACHIEVEMENT_BUILD_WALL_NAME,		//Wall Builder
			ACHIEVEMENT_BUILD_WALL_DESC,		//Build {0} Walls
			ACHIEVEMENT_UPGRADE_WALL_NAME,		//Iron Wall
			ACHIEVEMENT_UPGRADE_WALL_DESC,		//Upgrade one Wall to level {0}
			ACHIEVEMENT_UPGRADE_TANK_NAME,		//Vanguard
			ACHIEVEMENT_UPGRADE_TANK_DESC,		//Upgrade Mini Tank to level {0}
			ACHIEVEMENT_UPGRADE_MARINE_NAME,		//Marksman
			ACHIEVEMENT_UPGRADE_MARINE_DESC,		//Upgrade Marine to level {0}
			ACHIEVEMENT_UPGRADE_COLOSSUS_NAME,		//Taxman
			ACHIEVEMENT_UPGRADE_COLOSSUS_DESC,		//Upgrade Colossus to level {0}
			ACHIEVEMENT_UPGRADE_BULLDOZER_NAME,		//Irresistible Power
			ACHIEVEMENT_UPGRADE_BULLDOZER_DESC,		//Upgrade Demolisher to level {0}
			ACHIEVEMENT_UPGRADE_HEAL_DRONE_NAME,		//Remedium
			ACHIEVEMENT_UPGRADE_HEAL_DRONE_DESC,		//Upgrade Medic Drone to level {0}
			ACHIEVEMENT_UPGRADE_B52_NAME,		//Prolonged Oppression
			ACHIEVEMENT_UPGRADE_B52_DESC,		//Upgrade Oppressor to level {0}
			ACHI_UI_PROFILE_TAG,		//Profile
			ACHI_UI_CLAN_TAG,		//Alliance
			ACHI_UI_ALL_TIME_BEST,		//All time best
			ACHI_UI_ACHIEVEMENT_TXT,		//Achievements
			ACHI_UI_REWARD_TXT,		//Rewards:
			ACHI_UI_CLAIM_TXT,		//Claim
			ACHI_UI_DIALOG_TITLE,		//Congratulations!
			ACHI_UI_DIALOG_MESS,		//You earned the\n<color=#FFE400>{0}</color> achievement!
			BATTLE_LOG_DEFENSE_LOG,		//Defense Log
			BATTLE_LOG_ATTACK_LOG,		//Attack Log
			BATTLE_LOG_REPLAY,		//Replay
			EXIT_GAME_TITLE,		//Exit game!
			EXIT_GAME_TXT,		//Do you want to quit the game?
			DIALOG_BUY_ENERGY_TITLE,		//You need more energy
			DIALOG_BUY_ENERGY_MESS,		//Buy the missing {0} energy?
			DIALOG_BUY_ENERGY_BATTLE_TITLE,		//You need more energy
			DIALOG_BUY_ENERGY_BATTLE_MESS,		//Buy {0} energy for battle?
			DIALOG_EQUIP_TITLE,		//No Gun for Battle
			DIALOG_EQUIP_MESS,		//You need equip gun
			MISSING_MATERIAL,		//Insufficient materials!
			MISSING_MATERIAL_TEXT,		//Buy the missing {0}?
			IAP_GEMS_PACK_1_NAME,		//Handful of Gems
			IAP_GEMS_PACK_2_NAME,		//Bundle of Gems
			IAP_GEMS_PACK_3_NAME,		//Pocket of Gems
			IAP_GEMS_PACK_4_NAME,		//Pedestal of Gems
			IAP_GEMS_PACK_5_NAME,		//Capsule of Gems
			IAP_GEMS_PACK_6_NAME,		//Mountain of Gems
			IAP_GEMS_PACK_1_DESC,		//Handful of Gems
			IAP_GEMS_PACK_2_DESC,		//Bundle of Gems
			IAP_GEMS_PACK_3_DESC,		//Pocket of Gems
			IAP_GEMS_PACK_4_DESC,		//Pedestal of Gems
			IAP_GEMS_PACK_5_DESC,		//Capsule of Gems
			IAP_GEMS_PACK_6_DESC,		//Mountain of Gems
			IAP_PROMOTION_PACK_1_NAME,		//Ark {0} Pack
			IAP_PROMOTION_PACK_2_NAME,		//Starter Pack
			IAP_PROMOTION_PACK_1_DESC,		//Ark {0} Pack
			IAP_PROMOTION_PACK_2_DESC,		//Starter Pack
			SHOP_SHIELD_PACK_1_NAME,		//Two Hours Shield
			SHOP_SHIELD_PACK_2_NAME,		//One Day Shield
			SHOP_SHIELD_PACK_3_NAME,		//Two Days Shield
			SHOP_SHIELD_PACK_4_NAME,		//One Week Shield
			SHOP_SHIELD_PACK_1_DESC,		//Two Hours Shield
			SHOP_SHIELD_PACK_2_DESC,		//One Day Shield
			SHOP_SHIELD_PACK_3_DESC,		//Two Days Shield
			SHOP_SHIELD_PACK_4_DESC,		//One Week Shield
			RANK_UNRANK,		//Unrank
			RANK_AIRMAN_III,		//Airman III
			RANK_AIRMAN_II,		//Airman II
			RANK_AIRMAN_I,		//Airman I
			RANK_CORPORAL_III,		//Corporal III
			RANK_CORPORAL_II,		//Corporal II
			RANK_CORPORAL_I,		//Corporal I
			RANK_SERGEANT_III,		//Sergeant III
			RANK_SERGEANT_II,		//Sergeant II
			RANK_SERGEANT_I,		//Sergeant I
			RANK_CAPTAIN_III,		//Captain III
			RANK_CAPTAIN_II,		//Captain II
			RANK_CAPTAIN_I,		//Captain I
			RANK_MAJOR_III,		//Major III
			RANK_MAJOR_II,		//Major II
			RANK_MAJOR_I,		//Major I
			RANK_COLONEL_III,		//Colonel III
			RANK_COLONEL_II,		//Colonel II
			RANK_COLONEL_I,		//Colonel I
			RANK_BRIGARDIER_III,		//Brigardier III
			RANK_BRIGARDIER_II,		//Brigardier II
			RANK_BRIGARDIER_I,		//Brigardier I
			RANK_GENERAL_III,		//General III
			RANK_GENERAL_II,		//General II
			RANK_GENERAL_I,		//General I
			RANK_MARSHAL_III,		//Marshal III
			RANK_MARSHAL_II,		//Marshal II
			RANK_MARSHAL_I,		//Marshal I
			RANK_LEGEND_III,		//Legend III
			RANK_LEGEND_II,		//Legend II
			RANK_LEGEND_I,		//Legend I
			WAITE_COOLDOWN_TXT,		//This shield is on cool down!
			TXT_BUY_SHIELD_MESS,		//Do you want to buy this shield?
			TXT_SHIELD_REDUCE_TIME,		//Attack will reduce your shield by {0}
			WARN_ONLINE_ATTACK,		//Can't attack! Ark owner is online.
			WARN_SHIELD_ATTACK,		//Can't attack! Ark shield is active.
			WARN_REPLAY_NO_DATA,		//Replay is not available!
			TXT_REQUIRED_ARK_LEVEL,		//Required ARK level {0}
			TXT_LOADING_LOGO,		//Loading
			TXT_RANK_UP_TITLE,		//Rank Upgraded!
			TXT_MAX,		//Max capacity:
			TXT_PRODUCTION,		//Production per hour:
			TXT_MAX_ARK_LEVEL,		//The Ark reaches its max level for now. \n\nNew content will coming soon in next updates.
			TXT_REQUIRED_TALENT,		//Required {0}
			TXT_REQUIRED_TALENT_NODES,		//Required previous nodes
			FIND_MATCH_ERROR,		//No opponents available
			FIND_MATCH_NO_DATA,		//We cannot find a worthy opponent at this moment.\nPlease try again later.
			INFO_TITLE_SPEED,		//Speed
			INFO_TITLE_ATK_SPEED,		//Fire rate
			INFO_TITLE_QUANTITY,		//Quantity
			INFO_TITLE_CRIT_DMG,		//Critical damage
			INFO_TITLE_CRIT_CHANCE,		//Critical chance
			INFO_TITLE_DAMAGE,		//Damage/bullet
			INFO_TITLE_HIT_POINTS,		//Hitpoints
			INFO_TITLE_REGEN,		//Regen
			INFO_TITLE_TRACKING,		//Tracking duration
			INFO_TITLE_PROD_RATE,		//Production rate
			INFO_TITLE_COOL_DOWN,		//Cool down reduction
			INFO_TITLE_STUN,		//Stun Duration
			INFO_TITLE_DPS,		//Damage / sec
			OBJECT_TYPE_ON_LAND,		//Ground
			OBJECT_TYPE_ON_AIR,		//Air
			OBJECT_TYPE_ALL,		//Ground & Air
			TXT_DESC_BATTLE_NO_ATK_LOG,		//There is no battle recently!
			TXT_DESC_BATTLE_NO_DEF_LOG,		//There is no battle recently!
			TXT_SETTING_TITLE,		//Settings
			TXT_SETTING_MUSIC,		//Music
			TXT_SETTING_SFX,		//SFX
			TXT_SETTING_SUPPORT,		//Support
			TXT_SETTING_FANPAGE,		//Fanpage
			TXT_SETTING_TERM,		//Term of Service
			TXT_SETTING_POLICY,		//Privacy Policy
			TXT_SETTING_HAS_LOGIN,		//Connected
			TXT_SETTING_GOOGLEPLAY,		//Google Play
			TXT_SETTING_IOS,		//IOS
			TXT_SETTING_LOGIN,		//Login
			TXT_SETTING_STATUS_ON,		//ON
			TXT_SETTING_STATUS_OFF,		//OFF
			TXT_SETTING_LANGUAGE,		//English
			TXT_SETTING_PLAYERID,		//ID player: {0}
			TXT_SETTING_VERSION_BUILD,		//Version: {0}
			TXT_SETTING_VIBRATION,		//Vibration
			TXT_REPLAY_DEFENDER,		//Defender
			TXT_REPLAY_AVAILABLE_LOOT,		//Available Loot:
			TXT_REPLAY_ATTACKER,		//Attacker
			TXT_REPLAY_LOOT_GAINED,		//Loot gained:
			TXT_REPLAY_VS,		//VS
			TXT_REPLAY_END_IN,		//Replay ends in:
			TXT_REPLAY_RETURN_HOME,		//Return Home
			TXT_REPLAY_OVERALL_DAMAGE,		//Overall Damage
			TXT_REPLAY_TROOP_DEPLOYED,		//Troops Deployed:
			TXT_REPLAY_TOTAL_DAMAGE,		//Total damage:
			TXT_REPLAY_NO_UNIT,		//No unit deployed
			FAVORITE_TARGET_BUILDING,		//Buildings
			FAVORITE_TARGET_DEF_BUILDING,		//Defense buildings
			FAVORITE_TARGET_RES_BUILDING,		//Resource
			FAVORITE_TARGET_TROOP,		//Troops
			FAVORITE_TARGET_ALL,		//Any
			FAVORITE_TARGET_TROOP_ON_LAND,		//Ground Units
			FAVORITE_TARGET_TROOP_ON_AIR,		//Troops on Air
			TXT_BUTTON_UPGRADE,		//Upgrade
			TXT_BUTTON_UPGRADING,		//Upgrading
			TXT_BUTTON_UNLOCK,		//Unlock
			TXT_BUTTON_OKAY,		//OK
			TXT_BUTTON_ACTIVE,		//Active
			TXT_BUTTON_ACTIVED,		//Actived
			TXT_LEVEL_MAX,		//Max
			TXT_BUTTON_INFO,		//Info
			TXT_BUTTON_COLLECT,		//Collect
			TXT_BUTTON_FINISH,		//Finish
			TXT_NOTIFY_NEW,		//NEW
			TXT_LOADING_TERM_OF_SERVICE,		//By continuing to play, you agree to our <color=#02FDFA>Term of Service</color> For more info see our <color=#02FDFA>Privacy Policy</color>
			TXT_RATE_BUTTON,		//Vote
			TXT_RATE_BT_LATER,		//Later
			TXT_RATE_MESS,		//How do you enjoy Ark Rivals?
			TXT_RATE_TITLE,		//Rate us!
			TXT_RATE_DESC,		//Tap a star to rate us.
			TXT_AFTER_RATE_MESS,		//Your rating help us improve the game furthermore.
			TXT_AFTER_RATE_TITLE,		//Thank You!
			TXT_ATTACKED_TITLE,		//Our Ark was attacked!
			TXT_ATTACKED_MESS,		//The Ark was attacked {0} time{1} while you were away!
			TXT_ATTACKED_RESOURCE_LOST,		//Resource lost
			TXT_ATTACKED_TROPHY_WIN_LOST,		//Trophies Win / Lost
			TXT_ATTACKED_RESULT,		//Result:
			TXT_ATTACKED_BT_DETAIL,		//Detail
			TXT_COMING_SOON,		//Coming soon!
			TXT_REQUIRE_UNLOCK_AT_ARK,		//Unlock at ARK level {0}
			TXT_REQUIRE_UPGRADE_ARK,		//Upgrade ARK to level {0} to build more!
			TXT_MAXIMUM_AMOUNT_BUILDING,		//You already have the maximum amount of these units!
			TXT_CAMPAIGN_NAME_1,		//Loot Rush
			TXT_CAMPAIGN_NAME_2,		//Iron Wall
			TXT_CAMPAIGN_NAME_3,		//Anti Air
			TXT_CAMPAIGN_NAME_4,		//Mothership
			TXT_CAMPAIGN_NAME_5,		//Ark Rival
			TXT_CAMPAIGN_NAME_PVP,		//PvP
			TXT_BUILDING_UPGRADE_PROCEED,		//Proceed
			TXT_NOT_ENOUGH_RESOURCE_TO_SCOUT_BATTLE,		//Not enough resource to scout next Battle!
			TXT_PUSH_LOCAL_NOTIFY_BUILDING,		//{0} construction is completed!
			TXT_PUSH_LOCAL_NOTIFY_UPGRADE_BUILDING,		//{0} upgraded to level {1}.
			TXT_PUSH_LOCAL_NOTIFY_RESOURCE_FULL,		//All {0}s are ready to collect!
			TXT_PUSH_LOCAL_NOTIFY_ENERGY_FULL,		//Energy is full! Time to battle!
			TXT_TITLE_SURRENDER,		//Surrender?
			TXT_TITLE_END_BATTLE,		//End Battle?
			TXT_DESC_SURRENDER,		//You will lose this battle!\nAre you sure you want to surrender?
			TXT_DESC_END_BATTLE,		//Are you sure you want to end this battle?
			TXT_LANGUAGE_TITLE,		//Language
			TXT_UPDATE_RECOMMEND_TITLE,		//Recommend Update
			TXT_UPDATE_RECOMMEND_MESS,		//A new version is available, we suggest you upgrade to the new version for best experience gaming.
			TXT_UPDATE_FORCE_TITLE,		//Update Required
			TXT_UPDATE_FORCE_MESS,		//The game need to update to the lastest version to continue playing.\nWe apologize for this inconvinience.
			TXT_BUTTON_MAIL,		//MAIL
			TXT_BUTTON_GUID,		//GUILD
			TXT_BUTTON_SETTING,		//SETTINGS
			TXT_BUTTON_SHOP,		//SHOP
			TXT_BUTTON_BUILD,		//BUILD
			TXT_BUTTON_ATTACK,		//ATTACK
			TXT_ARK_MENU_TECHTREE,		//Tech Tree
			TXT_ARK_MENU_SHIP,		//Ship
			TXT_ARK_MENU_WEAPON,		//Weapon
			TXT_ARK_MENU_BARRACK,		//Army
			TXT_ARK_MENU_TALENT,		//Talents
			TXT_BUILD_TAB_BUILDING,		//Buildings
			TXT_BUILD_TAB_DEFENSE,		//Defense
			TXT_BUILD_TAB_RESOURCE,		//Resources
			TXT_LEVEL,		//Level
			LOADING_STEP_LOADING,		//Init system
			LOADING_STEP_LOAD_LOCALDATA,		//Cleaning pilot cockpit
			LOADING_STEP_LOAD_FIREBASE_REMOTE,		//Prepare to takeoff
			LOADING_STEP_LOAD_SERVERCONFIG,		//Dealing with aliens
			LOADING_STEP_CONNECT_SERVER,		//Report to HQ
			LOADING_STEP_LOAD_TUTORIAL,		//Ask for landing permission
			LOADING_STEP_LOAD_MAINBASE,		//Landing on the Ark
			TXT_CHANGE_NAME_TITLE,		//Enter your name
			TXT_CHANGE_NAME_MESS_FREE,		//You only get one free name change.\nUse it wisely as future name changes will cost you Gems.
			TXT_CHANGE_NAME_MESS_COST,		//Change your name with         {0}?
			TXT_CHANGE_NAME_MESS_INVALID,		//Invalid name, please pick another one.
			TXT_CLAN_COMING_SOON,		//Feature in developed, coming soon in future updates.
			TXT_TAP_TO_PLAY,		//Tap to play
			TXT_BUTTON_SURRENDER,		//Surrender
			TXT_BUTTON_ENDBATTLE,		//End Battle
			TXT_INBOX_TAB,		//Inbox
			TXT_INBOX_NO_MAIL,		//There is no mail recently!
			TXT_REWARD_TITLE_UPDATE_VERSION,		//Thank for staying with Ark Rival!
			TXT_REWARD_CONTENT_UPDATE_VERSION,		//Enjoy the fresh new winter update!\n\n- New contents for Ark tier 7: building, talents and more.\n- New defense structure: Land Mine.\n  Place them in strategic positions and give rivals army BIG suprises.\n- In this version, we improve the game performance to give you best gaming experience.\n\nLast but not least!\nWe would like to gift you some rewards as a appriciate token for your supports.\n\nBest Regards,\nThe Ark Rivals Team
			TXT_RE_ARM,		//Re-Arm
			TXT_RE_ARM_ALL,		//Re-Arm All
			TXT_GIFT,		//Gifts
			TXT_BUTTON_SELECT_ROW,		//Select row
			TXT_BUTTON_ROTATE,		//Rotate
			TXT_BUTTON_UPGRADE_ALL,		//Upgrade All
			TXT_NO_CLAN,		//No Clan
			TXT_CLAN_ALLIANCE,		//Alliance
			TXT_CLAN_ALLIANCE_SETTING,		//Alliance Setting
			TXT_CLAN_CREATE,		//Create Alliance
			TXT_CLAN_JOIN,		//Join Alliance
			TXT_CLAN_MY_ALLIANCE,		//My Alliance
			TXT_CLAN_NAME,		//Alliance Name:
			TXT_CLAN_DES,		//Desription:
			TXT_CLAN_BADGE,		//Badge
			TXT_CLAN_BT_EDIT,		//Edit
			TXT_CLAN_BT_CREATE,		//Create
			TXT_CLAN_MEMBER,		//Members:
			TXT_CLAN_TYPE,		//Type:
			TXT_CLAN_RE_TROPHY,		//Required trophies:
			TXT_CLAN_LOCATION,		//Alliance location:
			TXT_CLAN_BT_JOIN,		//Join
			TXT_CLAN_BT_LEAVE,		//Leave
			TXT_CLAN_BT_INVITE,		//Invite
			TXT_CLAN_BT_INVITED,		//Invited
			TXT_CLAN_SEARCH_ALLI,		//Search Alliances
			TXT_CLAN_TYPE_NAME_OR_ID,		//Type Alliance name or Alliance id
			TXT_CLAN_BT_SEARCH,		//Search
			TXT_CLAN_SUGGEST_ALLI,		//Suggested Alliances
			TXT_CLAN_SEND_MAIL,		//Send mail
			TXT_CLAN_BT_REJECT,		//Reject
			TXT_CLAN_BT_ACCEPT,		//Accept
			TXT_CLAN_TAP_TO_VIEW,		//Tap to view details
			TXT_CLAN_KEY_23,		//Donate
			TXT_CLAN_KEY_24,		//Donate resources to level up Alliance and get rewards weekly.
			TXT_CLAN_KEY_25,		//Claim reward in {0}
			TXT_CLAN_KEY_26,		//Invitation mail has been sent to this player.
			TXT_CLAN_KEY_27,		//Chat
			TXT_CLAN_BT_VISIT,		//Visit
			TXT_CLAN_BT_TO_LEADER,		//Promote to Leader
			TXT_CLAN_BT_TO_ELDER,		//Promote to Elder
			TXT_CLAN_BT_TO_MEMBER,		//Demote to member
			TXT_CLAN_BT_KICK_OUT,		//Kick out
			TXT_CLAN_PRMOTE_TITLE,		//Promote?
			TXT_CLAN_PRMOTE_LEADER,		//Promote {0} to Leader. You will demote to {1}. Are you sure?
			TXT_CLAN_PRMOTE_ELDER,		//Promote {0} to Elder?
			TXT_CLAN_DEMOTE_TITLE,		//Demote?
			TXT_CLAN_DEMOTE_MESS,		//Demote {0} to member?
			TXT_CLAN_KICK_OUT_TITLE,		//Kick out?
			TXT_CLAN_KICK_OUT_MESS,		//Do you want to kick out {0}?
			TXT_CLAN_KEY_38,		//Online:
			TXT_CLAN_KEY_40,		//Join or create an Alliance to chat.\nDonate resources to level up Alliance and get rewards weekly.
			TXT_CLAN_KEY_41,		//Join now
			TXT_CLAN_TYPE_PUBLIC,		//Anyone can join
			TXT_CLAN_TYPE_PRIVATE,		//Closed
			TXT_CLAN_TYPE_INVITE,		//Invite only
			TXT_CLAN_WARNING_TITLE,		//Canh Bao!
			TXT_CLAN_INPUT_CLAN_NAME,		//Pleas enter your Alliance name
			TXT_CLAN_CREATE_FAILED,		//Create Alliance failed!
			TXT_CLAN_EDIT_FAILED,		//Cannot update Alliance info!
			TXT_CLAN_LEAVE_MESS,		//Do you want to leave this Alliance?
			TXT_CLAN_LEAVE_FAILED,		//Leave Alliance success!
			TXT_CLAN_CHANGE_LEADER_MESS,		//You must transfer the Leader role to another member before leaving this Alliance!
			TXT_CLAN_JOIN_CLAN_MESS,		//You must leave your current Alliance to join into a new Alliance.
			TXT_CLAN_JOIN_INVITE_MESS,		//You need invitation to join this Alliance
			TXT_CLAN_JOIN_REQUIRE_TROPHY,		//You need {0} trophies or higher to join this Alliance.
			TXT_CLAN_JOIN_FAILED,		//Join Alliance failed!
			TXT_CLAN_FULL_MESS,		//This Alliance is full!
			SKILL_NAME_MissleSkill,		//Rocket Barrage
			SKILL_NAME_PhotonBlastSkill,		//Photon Blast
			SKILL_NAME_DroidFighterSkill,		//Wingmen Rider
			SKILL_NAME_ShieldSkill,		//Barrier Shield
			SKILL_NAME_BomberSkill,		//Cluster Bombs
			SHOP_GOLD_10_NAME,		//Fill storage by 10%
			SHOP_GOLD_50_NAME,		//Fill storage by 50%
			SHOP_GOLD_100_NAME,		//Fill full storage
			SHOP_FUEL_10_NAME,		//Fill storage by 10%
			SHOP_FUEL_50_NAME,		//Fill storage by 50%
			SHOP_FUEL_100_NAME,		//Fill full storage
			TXT_BUY_RESOURCE_MESS,		//Do you want to fill {0} {1}?
			IAP_PROMOTION_STARTER_PACK_NAME,		//Starter Pack
			BTN_USE_SPEED_UP,		//Use
			TXT_CONSTRUCTING_SPEED_UP,		//Constructing...
			TXT_INFO_SPEED_UP,		//Reduces construction time by
			TXT_HAVE_SPEED_UP,		//Have:
			TXT_SPEED_UP,		//Speed Up
			REPLAY_NO_DATA_TITLE,		//Replay is not available!
			REPLAY_NO_DATA_MESSAGE,		//Cannot retrieve replay!
			TXT_TALENT_CONTENT_UPGRADE,		//Upgrade
			TXT_TALENT_CONTENT_ALL,		//All
			TXT_WEAPON_TYPE_SPECIAL,		//Special
			TXT_WEAPON_TYPE_PRIMARY,		//Primary
			GUN_LIGHT_1A_GROUP,		//Primary Weapon
			GUN_LIGHT_1A_INFO,		//Pulse Laser
			GUN_LIGHT_1B_GROUP,		//Primary Weapon
			GUN_LIGHT_1B_INFO,		//Quantum Beam
			GUN_LIGHT_1C_GROUP,		//Primary Weapon
			GUN_LIGHT_1C_INFO,		//Helix Cannon
			GUN_LIGHT_1D_GROUP,		//Primary Weapon
			GUN_LIGHT_1D_INFO,		//Lightning Conduit
			GUN_LIGHT_1E_GROUP,		//Primary Weapon
			GUN_LIGHT_1E_INFO,		//Starfire Blast
			GUN_HEAVY_1A_GROUP,		//Special Weapon
			GUN_HEAVY_1A_INFO,		//Hydra Cannon
			GUN_HEAVY_1B_GROUP,		//Special Weapon
			GUN_HEAVY_1B_INFO,		//Photon Array
			GUN_HEAVY_1C_GROUP,		//Special Weapon
			GUN_HEAVY_1C_INFO,		//Kinsectoid Lair
			GUN_HEAVY_1D_GROUP,		//Special Weapon
			GUN_HEAVY_1D_INFO,		//Space Furnace
			GUN_HEAVY_1E_GROUP,		//Special Weapon
			GUN_HEAVY_1E_INFO,		//Ethereal Vortex
			TROOP_MARINE_GROUP,		//Troop Unlock
			TROOP_MARINE_INFO,		//Marine
			TROOP_TANK_GROUP,		//Troop Unlock
			TROOP_TANK_INFO,		//Mini Tank
			TROOP_CHOPPER_GROUP,		//Troop Unlock
			TROOP_CHOPPER_INFO,		//Chopper
			TROOP_HEAL_DRONE_GROUP,		//Troop Unlock
			TROOP_HEAL_DRONE_INFO,		//Medic Drone
			TROOP_BULLDOZER_GROUP,		//Troop Unlock
			TROOP_BULLDOZER_INFO,		//Demolisher
			TROOP_FLAMER_GROUP,		//Troop Unlock
			TROOP_FLAMER_INFO,		//TROOP_FLAMER_INFO
			TROOP_B52_GROUP,		//Troop Unlock
			TROOP_B52_INFO,		//Oppressor
			TROOP_BOMB_GROUP,		//Troop Unlock
			TROOP_BOMB_INFO,		//Bomber Droid
			TROOP_COLOSSUS_GROUP,		//Troop Unlock
			TROOP_COLOSSUS_INFO,		//Colossus
			TALENT_LIGHT_WEAPON_ATK_SPD_GROUP,		//Weapon Upgrade
			TALENT_LIGHT_WEAPON_ATK_SPD_INFO,		//Fire Rate
			TALENT_TROOP_MARINE_QUANTITY_GROUP,		//Troop Upgrade
			TALENT_TROOP_MARINE_QUANTITY_INFO,		//Marine Quantity
			TALENT_TROOP_TANK_DMG_GROUP,		//Troop Upgrade
			TALENT_TROOP_TANK_DMG_INFO,		//Mini Tank Damage
			TALENT_LIGHT_DMG_GROUP,		//Weapon Upgrade
			TALENT_LIGHT_DMG_INFO,		//Primary Damage
			TALENT_LIGHT_CRIT_CHANCE_GROUP,		//Weapon Upgrade
			TALENT_LIGHT_CRIT_CHANCE_INFO,		//Critical Chance
			TALENT_HEAVY_COOL_DOWN_GROUP,		//Weapon Upgrade
			TALENT_HEAVY_COOL_DOWN_INFO,		//Special Cooldown
			TALENT_SHIP_HP_UP_GROUP,		//Ship Upgrade
			TALENT_SHIP_HP_UP_INFO,		//Hitpoints
			TALENT_TROOP_HEAL_DRONE_SPD_GROUP,		//Troop Upgrade
			TALENT_TROOP_HEAL_DRONE_SPD_INFO,		//Medic Drone Speed
			TALENT_TROOP_FLAMER_HP_GROUP,		//TALENT_TROOP_FLAMER_HP_GROUP
			TALENT_TROOP_FLAMER_HP_INFO,		//TALENT_TROOP_FLAMER_HP_INFO
			TALENT_LIGHT_CRIT_DMG_GROUP,		//Weapon Upgrade
			TALENT_LIGHT_CRIT_DMG_INFO,		//Critical Damage
			TALENT_HEAVY_DMG_GROUP,		//Weapon Upgrade
			TALENT_HEAVY_DMG_INFO,		//Special Power
			TALENT_TROOP_RAMBO_REGEN_GROUP,		//TALENT_TROOP_RAMBO_REGEN_GROUP
			TALENT_TROOP_RAMBO_REGEN_INFO,		//TALENT_TROOP_RAMBO_REGEN_INFO
			TALENT_TROOP_BULLDOZER_SPD_GROUP,		//Troop Upgrade
			TALENT_TROOP_BULLDOZER_SPD_INFO,		//Demolisher Speed
			TALENT_TROOP_CHOPPER_DMG_GROUP,		//Troop Upgrade
			TALENT_TROOP_CHOPPER_DMG_INFO,		//Chopper Damage
			TALENT_TROOP_COLOSSUS_HP_GROUP,		//Troop Upgrade
			TALENT_TROOP_COLOSSUS_HP_INFO,		//Colossus HP
			TALENT_TROOPS_DMG_GROUP,		//Troop Upgrade
			TALENT_TROOPS_DMG_INFO,		//All Troops Damage
			TALENT_TROOPS_HP_GROUP,		//Troop Upgrade
			TALENT_TROOPS_HP_INFO,		//All Troops HP
			TALENT_ARK_HP_GROUP,		//Ark Upgrade
			TALENT_ARK_HP_INFO,		//Hitpoints
			TALENT_TROOP_TANK_HP_GROUP,		//Troop Upgrade
			TALENT_TROOP_TANK_HP_INFO,		//Mini Tank HP
			TALENT_BUILDING_MINE_PROD_RATE_GROUP,		//Buildings Upgrade
			TALENT_BUILDING_MINE_PROD_RATE_INFO,		//Production Rate
			TALENT_BUILDING_MINE_HP_GROUP,		//Buildings Upgrade
			TALENT_BUILDING_MINE_HP_INFO,		//Buildings Hitpoints
			TALENT_TURRET_MINI_DMG_GROUP,		//Turrets Upgrade
			TALENT_TURRET_MINI_DMG_INFO,		//Mini Gun Damage
			TALENT_TURRET_MISSILE_TRACK_TIME_GROUP,		//Turrets Upgrade
			TALENT_TURRET_MISSILE_TRACK_TIME_INFO,		//Missile Damage
			TALENT_TURRET_FIRE_BURN_DMG_GROUP,		//Turrets Upgrade
			TALENT_TURRET_FIRE_BURN_DMG_INFO,		//Flamethrower Damage
			TALENT_TURRET_PHOTON_HP_GROUP,		//Turrets Upgrade
			TALENT_TURRET_PHOTON_HP_INFO,		//Photon Hitpoints
			TALENT_TURRET_THUNDER_CHAIN_GROUP,		//Turrets Upgrade
			TALENT_TURRET_THUNDER_CHAIN_INFO,		//Bolt Caster Damage
			TALENT_BUILDING_MINE_BOMB_DMG_GROUP,		//Defense Upgrade
			TALENT_BUILDING_MINE_BOMB_DMG_INFO,		//Land Mine Damage
			TALENT_TURRET_FIRE_HP_GROUP,		//Turrets Upgrade
			TALENT_TURRET_FIRE_HP_INFO,		//Flamethrower HP
			TALENT_TURRET_PHOTON_ATK_SPD_GROUP,		//Turrets Upgrade
			TALENT_TURRET_PHOTON_ATK_SPD_INFO,		//Photon Fire Rate
			TALENT_TURRET_THUNDER_STUN_TIME_GROUP,		//Turrets Upgrade
			TALENT_TURRET_THUNDER_STUN_TIME_INFO,		//Bolt Stun Time
			TALENT_BUILDING_SHIELD_GENERATOR_HP_GROUP,		//Defense Upgrade
			TALENT_BUILDING_SHIELD_GENERATOR_HP_INFO,		//Shield HP
			TALENT_HQ_DMG_GROUP,		//Ark Upgrade
			TALENT_HQ_DMG_INFO,		//Damage
			TALENT_HQ_HP_GROUP,		//Ark Upgrade
			TALENT_HQ_HP_INFO,		//HItpoints
			TALENT_TROOP_TANK_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_TANK_MAX_DEPLOY_INFO,		//Mini Tank
			TALENT_TROOP_MARINE_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_MARINE_MAX_DEPLOY_INFO,		//Marine
			TALENT_TROOP_COLOSSUS_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_COLOSSUS_MAX_DEPLOY_INFO,		//Colossus
			TALENT_TROOP_BULLDOZER_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_BULLDOZER_MAX_DEPLOY_INFO,		//Demolisher
			TALENT_TROOP_HEAL_DRONE_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_HEAL_DRONE_MAX_DEPLOY_INFO,		//Medic Drone
			TALENT_TROOP_CHOPPER_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_CHOPPER_MAX_DEPLOY_INFO,		//Chopper
			TALENT_TROOP_SPIDER_BOMB_MAX_DEPLOY_GROUP,		//Max Deploy
			TALENT_TROOP_SPIDER_BOMB_MAX_DEPLOY_INFO,		//Bomber Droid
			SHIP_NORMAL_1A_GROUP,		//Ship
			SHIP_NORMAL_1A_INFO,		//Falcon MK-1
			SHIP_NORMAL_1B_GROUP,		//Ship
			SHIP_NORMAL_1B_INFO,		//Falcon MK-2
			SHIP_NORMAL_1C_GROUP,		//Ship
			SHIP_NORMAL_1C_INFO,		//Falcon MK-3
			SHIP_LIGHT_1A_GROUP,		//Ship
			SHIP_LIGHT_1A_INFO,		//Phoenix MK-1
			SHIP_LIGHT_1B_GROUP,		//Ship
			SHIP_LIGHT_1B_INFO,		//Phoenix MK-2
			SHIP_LIGHT_1C_GROUP,		//Ship
			SHIP_LIGHT_1C_INFO,		//Phoenix MK-3
			SHIP_HEAVY_1A_GROUP,		//Ship
			SHIP_HEAVY_1A_INFO,		//Hammer MK-1
			SHIP_HEAVY_1B_GROUP,		//Ship
			SHIP_HEAVY_1B_INFO,		//Hammer MK-2
			SHIP_HEAVY_1C_GROUP,		//Ship
			SHIP_HEAVY_1C_INFO,		//Hammer MK-3
			TXT_TRAINING_DIALOG_UNLOCK_SLOT_TITLE,		//Army Slot
			TXT_TRAINING_DIALOG_UNLOCK_SLOT_DESC,		//Do you want to unlock Army slot?
			TXT_TRAINING_ARMY,		//ARMY
			TXT_TRAINING_REQUIRE_ARK,		//Required Ark
			TXT_TRAINING_WARNING_FULL_CAPACITY,		//Army max capacity reached!
			TXT_TRAINING_WARNING_FULL_SLOT,		//No more slot to assign army!
			TXT_TRAINING_UNLOCK_ON_TALENT,		//Unlock in Tech Tree
			TXT_UPGRADE_WALL_ROW,		//Upgrade Walls!
			TXT_UPGRADE_WALL_ROW_DESC,		//Do you want to upgrade the selected {0}?
			GOLD_OBS_1x1_1,		//Gold Obstacle 1
			GOLD_OBS_2x2_1,		//Gold Obstacle 2
			GOLD_OBS_3x3_1,		//Gold Obstacle 3
			GOLD_OBS_4x4_1,		//Gold Obstacle 4
			GOLD_OBS_5x5_1,		//Gold Obstacle 5
			GOLD_OBS_6x6_1,		//Gold Obstacle 6
			FUEL_OBS_1x1_1,		//Fuel Obstacle 1
			FUEL_OBS_2x2_1,		//Fuel Obstacle 2
			FUEL_OBS_3x3_1,		//Fuel Obstacle 3
			FUEL_OBS_4x4_1,		//Fuel Obstacle 4
			FUEL_OBS_5x5_1,		//Fuel Obstacle 5
			FUEL_OBS_6x6_1,		//Fuel Obstacle 6
			TOP_CLAN_TAB_TXT,		//Top Clans
			TOP_PLAYE_TAB_TXT,		//Top Players
			TXT_ATTACK_WON,		//Attacks won:
			TXT_DEFENSE_WON,		//Defense won:
	}

	public static class LocalizedTextContainer
	{
		private static string[] ListText;
		private static int maxLength;

		public static void LoadText(string language)
		{
			var fileName = "";
			switch (language)
			{
				case "en":
					fileName = "[en]LocalizedText";
					break;

				case "vi":
					fileName = "[vi]LocalizedText";
					break;

				case "fr":
					fileName = "[fr]LocalizedText";
					break;

				case "de":
					fileName = "[de]LocalizedText";
					break;

				case "pt":
					fileName = "[pt]LocalizedText";
					break;

				case "es":
					fileName = "[es]LocalizedText";
					break;

				case "zh":
					fileName = "[zh]LocalizedText";
					break;

				case "ja":
					fileName = "[ja]LocalizedText";
					break;

				case "ko":
					fileName = "[ko]LocalizedText";
					break;

				case "ru":
					fileName = "[ru]LocalizedText";
					break;


			}

			try
			{
				var jsonString = (Resources.Load(fileName) as TextAsset)?.text;
				var nodes = JSON.Parse(jsonString);
				var texts = (JSONArray) nodes[language];
				maxLength = texts.Count;
				ListText = new string[maxLength];

				var i = 0;
				foreach (var text in texts)
				{
					ListText[i] = text.Value;	i++;
				}
			}
			catch (Exception e)
			{
				Debug.LogError($"LocalizedText can not load json file: {fileName} => err: {e}");
			}
		}

		public static string GetText(LocalizedTextKey key)
		{
			try
			{
				if ((int) key < maxLength)
				{
					return ListText[(int) key];
				}
			}
			catch (Exception e)
			{
				Debug.LogError($"LocalizedText not exits key: {key} => err: {e}");
			}

			return key.ToString();
		}
	}
}