define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
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
			}
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
			}
		]/**SCHEMA_DIFF*/
	};
});
