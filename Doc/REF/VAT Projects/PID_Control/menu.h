typedef struct
{
	char *label;
	uint8_t withdata;
	float *data;
	float *data_max;
	float *data_min;
	float *data_adjust;
	uint8_t parent_id;
	uint8_t child_id;
} item;

typedef struct
{
	uint8_t id;
	uint8_t num_items;
	item *item[5];
} menu;

typedef struct
{
	uint8_t id;
	item *item[1];
} menu_edit;

// Speed Menu's items
item set_spd_item = {"Set Spd: ",1,&set_speed,&set_speed_max,&set_speed_min,&set_speed_adjust,0,1};

item fbk_spd_item = {"Fbk Spd: ",1,&fbk_speed,&null,&null,&null,0,0};

item Kp_item = {"Kp: ",1,&Kp,&Kp_max,&Kp_min,&Kp_adjust,0,1};

item Ki_item = {"Ki: ",1,&Ki,&Ki_max,&Ki_min,&Ki_adjust,0,1};

item Kd_item = {"Kd: ",1,&Kd,&Kd_max,&Kd_min,&Kd_adjust,0,1};

//Speed Edit Menus' items
item set_spd_item_edit = {"Set Spd: ",1,&set_speed,&set_speed_max,&set_speed_min,&set_speed_adjust,1,0};

item Kp_item_edit = {"Kp: ",1,&Kp,&Kp_max,&Kp_min,&Kp_adjust,1,0};

item Ki_item_edit = {"Ki: ",1,&Ki,&Ki_max,&Ki_min,&Ki_adjust,1,0};

item Kd_item_edit = {"Kd: ",1,&Kd,&Kd_max,&Kd_min,&Kd_adjust,1,0};

//Position Menu's items
item set_pos_item = {"Set Pos: ",1,&set_pos,&set_pos_max,&set_pos_min,&set_pos_adjust,2,3};

item fbk_pos_item = {"Fbk Pos: ",1,&fbk_pos,&null,&null,&null,2,3};

item start_spd_item = {"StartSpd: ",1,&start_spd,&start_spd_max,&start_spd_min,&start_spd_adjust,2,3};

item top_spd_item = {"Top Spd: ",1,&top_spd,&top_spd_max,&top_spd_min,&top_spd_adjust,2,3};

item acc_dec_item = {"Acc/Dec: ",1,&acc,&acc_max,&acc_min,&acc_adjust,2,3};

//Position Edit Menus' items
item set_pos_item_edit = {"Set Pos: ",1,&set_pos,&set_pos_max,&set_pos_min,&set_pos_adjust,3,2};

item start_spd_item_edit = {"StartSpd: ",1,&start_spd,&start_spd_max,&start_spd_min,&start_spd_adjust,3,2};

item top_spd_item_edit = {"Top Spd: ",1,&top_spd,&top_spd_max,&top_spd_min,&top_spd_adjust,3,2};

item acc_dec_item_edit = {"Acc/Dec: ",1,&acc,&acc_max,&acc_min,&acc_adjust,3,2};

//Speed Menus
menu speed_menu = {0,5,&set_spd_item,&fbk_spd_item,&Kp_item,&Ki_item,&Kd_item};

menu_edit edit_set_spd = {1,&set_spd_item_edit};

menu_edit edit_Kp = {1,&Kp_item_edit};

menu_edit edit_Ki = {1,&Ki_item_edit};

menu_edit edit_Kd = {1,&Kd_item_edit};

//Position Menus
menu position_menu = {2,5,&set_pos_item,&fbk_pos_item,&start_spd_item,&top_spd_item,&acc_dec_item};

menu_edit edit_set_pos = {3,&set_pos_item_edit};

menu_edit edit_start_spd = {3,&start_spd_item_edit};

menu_edit edit_top_spd = {3,&top_spd_item_edit};

menu_edit edit_acc_dec = {3,&acc_dec_item_edit};
