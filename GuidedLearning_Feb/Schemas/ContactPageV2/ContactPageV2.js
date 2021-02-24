define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		messages: {
			//Published on: ContactSectionV2.GuidedLearning
			"SectionActionClicked": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			"Account": {
				lookupListConfig: {
					columns: ["Web", "Country","Region", "City"]
				}
			},
			"MyAttr" :{
				//dataValueType: this.Terrasoft.DataValueType.TEXT,
				dependencies: [
					{
						columns: ["JobTitle", "Name"],
						methodName: "onFieldChanged"
					}
				]
			},
			"TempData": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: "https://creatio.com",
				caption: "Temp Data (Cap)"
			}

		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			
			
			/**
			 * @inheritdoc Terrasoft.BaseViewModule#init
			 * @overridden
			 */
			init: function(){
				this.callParent(arguments);
				this.subscribeToMessages();
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 * @protected
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
			},
			onFieldChanged: function(a, sender){
				var newValue = this.get(sender);
				var text = Ext.String.format("{0} {1}", sender, newValue);
				this.showInformationDialog(text);
			},
			onMuButtonClick: function(){
				
				var tag = arguments[3];
				var id = this.$Id;
				this.showInformationDialog(id);
				debugger;
			},
			onSubClick:function(){
				var tag =  arguments[0];
				if(tag === "111"){
					var username = "Academy-Creatio/Gl_Feb";
					this.$TempData = Ext.String.format("{0}{1}", "https://github.com/", username );
				}
			},
			onContBtnCLick: function(){
				var tag =  arguments[3];
				var id = this.$Id;
				this.showInformationDialog(id);
				//debugger;
			},
			subscribeToMessages: function(){
				this.sandbox.subscribe(
					"SectionActionClicked",
					function(){this.onSectionMessageReceived();},
					this, 
					["THIS_IS_MY_TAG2"]);
			},
			onSectionMessageReceived: function(){
				//this.showInformationDialog("message received from section");

				var yB = this.Terrasoft.MessageBoxButtons.YES;
				yB.style = "GREEN";
				
				var nB = this.Terrasoft.MessageBoxButtons.NO;
				nB.style = "RED";
				
				this.showConfirmationDialog(
					"ARE YOU SURE YOU WANT TO PROCEED ?",
					function (returnCode) {
						if (returnCode === this.Terrasoft.MessageBoxButtons.NO.returnCode) {
							return;
						}
						console.log("you clicked yes");
					},
					[
						//this.Terrasoft.MessageBoxButtons.NO.returnCode,
						//this.Terrasoft.MessageBoxButtons.YES.returnCode
						yB.returnCode,
						nB.returnCode
					],
					null
				);
			},
			/**
			 * Converter for URL
			 * @param {string} value 
			 */
			getUsrURLpageLink: function(value) {
				return {
						"url": value,
						"caption": value
				};
			},

			/**
			 * Event handler for when the lick is clicked
			 * @param {string} url 
			 */
			onUsrURLpageLinkClick: function(url) {
				if (url != null) {
					window.open(url, "_blank");
					return false;
			}
			},
			
			/**
			 * Allows you to add your own custom actions
			 * @inheritdoc Terrasoft.BasePageV2#getActions
			 * @overridden
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuSeparator());
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Tag": "onContBtnCLick",
					"Caption": "My Action (Page)",
					"ImageConfig": this.get("Resources.Images.CreatioCircle")
				}));
				return actionMenuItems;
			},
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Age",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 6,
						"row": 3
					},
					"enabled": false,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.AgeTip"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ContactGeneralInfoBlock",
				"propertyName": "items",
				"name": "MyButton",
				"values": {
					"layout": {
						"column": 18,
						"row": 3,
						"colSpan": 6
					},
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.RED,
					"click": {"bindTo": "onMuButtonClick"},
					"caption": {"bindTo": "Resources.Strings.MyBtnCaption"},
					"hint": "My Button Hint",
					"tag": "MyButtonTag",
					"menu": {
						"items": [
							{
								caption: "GitHub",
								click: {bindTo: "onSubClick"},
								visible: true,
								tag: "111"
							 },
							 {
								 caption: "YouTube",
								 click: {bindTo: "onSubClick"},
								 visible: true,
								 tag: "222"
							  }
						],
					}
				},
				
			},
			{
				// Indicates that an operation of adding an item to the page is being executed.
				"operation": "insert",
				// Metadata of the parent control item the button is added.
				"parentName": "LeftContainer",
				 // Indicates that the button is added to the control items collection
				 // of the parent item (which meta-name is specified in the parentName).
				"propertyName": "items",
				// Meta-name of the added button.
				"name": "PrimaryContactButton",
				// Supplementary properties of the item.
				"values": {
					// Type of the added item is button.
					itemType: Terrasoft.ViewItemType.BUTTON,
					style: Terrasoft.controls.ButtonEnums.style.GREEN,
					//  Binding the button title to a localizable string of the schema..
					caption: "PAGE BTN",
					// Binding the button press handler method.
					click: {bindTo: "onContBtnCLick"},
					tag: "111"
				}
			},

			/**TEMP DATA */
			{
				"operation": "insert",
				"name": "TempData",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 6,
						"row": 6,
						"layoutName": "ContactGeneralInfoBlock"
					},
					"bindTo": "TempData",
					"tip": {
						"content": "Transient data"
					},
					"showValueAsLink": true,
					"href": {
						"bindTo": "TempData",
						"bindConfig": {
							"converter": "getUsrURLpageLink"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.TextEdit",
						"linkclick": {
							"bindTo": "onUsrURLpageLinkClick"
						}
					}
				},
				"parentName": "ContactGeneralInfoBlock",
				"propertyName": "items",
				"index": 9
			},
		]/**SCHEMA_DIFF*/
	};
});
