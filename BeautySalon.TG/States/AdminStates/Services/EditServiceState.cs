﻿using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Services.EditDuration;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Services;

public class EditServiceState : AbstractState
{
    public EditServiceState(int typeId, int serviceId, string password)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceEdit(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        if (update.CallbackQuery.Data != "вернуться к выбору типа услуг")
        {
            if (update.CallbackQuery.Data == "удалить")
            {
                servicesHandler.ServiceRemove(SingletoneStorage.GetStorage().Client, update, ServiceId);
            }
            if (update.CallbackQuery.Data == "изменить цену")
            {
                return new EditPriceState(TypeId, ServiceId, Password);
            }
            if (update.CallbackQuery.Data == "изменить название")
            {
                return new EditTitleState(TypeId, ServiceId, Password);
            }
            if (update.CallbackQuery.Data == "изменить продолжительность")
            {
                return new EditDurationState(TypeId, ServiceId, Password);
            }
            // if (update.CallbackQuery.Data == "вернуться к выбору услуги")
            // {
            //     return new ServiceForModifyState(Password);
            // }
            if (update.CallbackQuery.Data == "вернуться к выбору типа услуг")
            {
                return new ServiceForModifyState(Password);
            }
            if (update.CallbackQuery.Data == "вернуться в меню админа")
            {
                return new AdminControlPanelState(Password);
            }
            if (update.CallbackQuery.Data == "перейти в меню клиента")
            {
                return new StartState();
            }
        }
        return new ServiceForModifyState(Password);
    }
}