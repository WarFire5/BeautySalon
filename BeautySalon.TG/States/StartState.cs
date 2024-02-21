using BeautySalon.TG.MessageHandlers;
using BeuatySalon.TG.States;
using BeuatySalon.TG.States.MyRecordsState;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States;

public class StartState : AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserWelcomeHandler userWelcomeHandler = new UserWelcomeHandler();
        userWelcomeHandler.WelcomeUser(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        //проверяем, что пришедшее сообщение является нажатием на кнопку и не равно null
        if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
        {
            if (update.CallbackQuery.Data.ToLower() == "записаться")
            {
                return new ServiceState();
            }
            else if (update.CallbackQuery.Data.ToLower() == "как добраться") //"как добраться"
            {
                return new HowToGetState();
            }
            else if (update.CallbackQuery.Data.ToLower() == "мои записи") //"Мои записи"
            {
                return new MyRecords();
            }
            else if (update.CallbackQuery.Data.ToLower() == "оставить отзыв") //"Оставить отзыв"
            {
                return new LeaveFeedbackState();
            }
            else if(update.CallbackQuery.Data.ToLower() == "Я сотрудник")
            {
                return new StaffEntranceState();
            }
        }
        return this;
    }
}