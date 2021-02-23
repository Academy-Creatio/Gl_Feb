define("ActivitySectionV2", [], function() {
	return {
		entitySchemaName: "Activity",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {
			/**
			 * @inheritdoc Terrasoft.BasePageV2#init
			 * @overridden
			 */
			init: function(){
				this.callParent(arguments);
				this.Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this.onOurMessage, this);
			},
			/**
			 * @inheritDoc Terrasoft.BasePageV2#destroy
			 * @overridden
			 */
			destroy: function() {
				this.Terrasoft.ServerChannel.un(this.Terrasoft.EventName.ON_MESSAGE, this.onOurMessage, this);
				this.callParent(arguments);
			},
			/**
			 * Our handler for when a websocket message arrives.
			 * Please make sure to encode message as proper json object
			 * @param {*} scope 
			 * @param {object} message sent from the backend
			 */
			onOurMessage: function(scope, message){
				var msg = message;
				if(msg.Header.Sender === "ActivityEventListener"){
					var event = JSON.parse(message.Body).Event;
					var text = JSON.parse(message.Body).Text;
					this.showInformationDialog(text);
					this.updateSection();
				}
			}
		}
	};
});
