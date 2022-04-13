using System;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using MyEchoBot.Models;

namespace MyEchoBot.Services
{
    public class StateService
    {
        // State Variable
        public ConversationState ConversationState { get; }
        public UserState UserState { get; }
        public DialogState DialogState { get; }

        // IDs
        public static string UserProfileId { get; } = $"{nameof(StateService)}.UserProfile";
        public static string ConversationDataId { get; } = $"{nameof(StateService)}.ConversationData";
        public static string DialogStateId { get; } = $"{nameof(DialogState)}.ConversationData";

        // Accesssors
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }
        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; set; }

        public StateService(ConversationState conversationState, UserState userState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));

            InitializaAccesssors();
        }

        public void InitializaAccesssors()
        {
            
            // Initialize Conversation State
            ConversationDataAccessor =  ConversationState.CreateProperty<ConversationData>(ConversationDataId);
            DialogStateAccessor =  ConversationState.CreateProperty<DialogState>(DialogStateId);

            // Initialize User State
            UserProfileAccessor =  UserState.CreateProperty<UserProfile>(UserProfileId);
        }
    }
}