define("ContactSectionV2", [], function() {
	return {
		entitySchemaName: "Contact",
		messages: {
			//Subscribed on: ContactPageV2.GuidedLearning
			"SectionActionClicked": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
                // The operation of adding a component to the page is in progress..
                "operation": "insert",
                // The meta name of the parent container to which the button is added.
                "parentName": "ActionButtonsContainer",
                // The button is added to the parent component's collection.
                "propertyName": "items",
                // The meta-name of the button to be added.
                "name": "MainContactSectionButton",
                // Properties passed to the component's constructor.
                "values": {
                    // The type of the component to add is the button.
                    itemType: Terrasoft.ViewItemType.BUTTON,
					style: Terrasoft.controls.ButtonEnums.style.RED,
                    // Bind the button header to the localizable string of the schema.
                    caption: "SECTION",
                    // Bind the button click handler method.
                    click: { bindTo: "onBtnCLick" },
					tag: "111",
                    // Setting the location of the button.
                    "layout": {
                        "column": 1,
                        "row": 6,
                        "colSpan": 1
                    }
                }
            },
			{
				// Indicates that an operation of adding an item to the page is being executed.
				"operation": "insert",
				// Meta-name of the parent control item where the button is added.
				"parentName": "CombinedModeActionButtonsCardLeftContainer",
				// Indicates that the button is added to the control items collection
				// of the parent item (which name is specified in the parentName).
				"propertyName": "items",
				// Meta-name of the added button. .
				"name": "MainContactButton",
				// Supplementary properties of the item.
				"values": {
					// Type of the added item is button.
					itemType: Terrasoft.ViewItemType.BUTTON,
					style: Terrasoft.controls.ButtonEnums.style.BLUE,
					// Binding the button title to a localizable string of the schema.
					caption: "SECTION C",
					// Binding the button press handler method.
					click: {bindTo: "onBtnCLick"},
					// Setting the field location.
					"layout": {
						"column": 1,
						"row": 6,
						"colSpan": 1
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {
			onBtnCLick: function(){
				var tag = arguments[3];
				this.sandbox.publish("SectionActionClicked", "message body", ["THIS_IS_MY_TAG2"]);
			},

			onMySectionActionClick: function(){
				this.showInformationDialog("Action clicked");
			},


			getSectionActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					Type: "Terrasoft.MenuSeparator",
					Caption: ""
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "onMySectionActionClick"},
					"Caption": "My Action (Section)",
					"Enabled": {"bindTo": "isAnySelected"}
				}));
				return actionMenuItems;
			},
		}
	};
});
