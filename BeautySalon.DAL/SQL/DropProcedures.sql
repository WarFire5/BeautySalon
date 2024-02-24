--удаление процедур
    --процедуры для админа
drop proc AddUserByChatId
drop proc GetWorkerNameByPassword
drop proc ChangeChatIdAndUserNameByPassword
drop proc GetAllUsersChatId
drop proc GetClientByNameAndId
drop proc GetClientByNameAndPhone
drop proc GetMasterByNameAndId
drop proc GetMasterByNameAndPhone
drop proc GetAllWorkersByRoleId
drop proc GetAllWorkersWithContactsByUserId
drop proc AddWorkerByRoleId
drop proc RemoveUserById
drop proc GetAllShiftsOnToday
drop proc GetAllShiftsAndEmployeesOnToday
drop proc GetMastersFromShiftByShiftTitle
drop proc RemoveMasterFromShiftByShiftTitle
drop proc ChangeMasterInShift
drop proc RemoveMasterFromShift
drop proc GetAllIntervals
drop proc GetAllIntervalsByShiftId
drop proc GetAllServiceTypes
drop proc GetAllServicesByIdFromCurrentType
drop proc GetAllServices
drop proc AddServiceById
drop proc UpdateServiceTitle
drop proc UpdateServicePrice
drop proc UpdateServiceDuration
drop proc RemoveServiceById
drop proc AddClientToFreeMaster
drop proc GetAllOrdersOnToday
drop proc GetAllOrdersOnTodayForMasters
     --процедуры для мастера
drop proc GetMastersShiftsById
drop proc GetOrdersByMasterId
     --процедуры для клиента
drop proc GetFreeMastersAndIntervalsOnToday
drop proc GetAllShiftsWithFreeIntervalsOnToday
drop proc GetAllFreeIntervalsByShiftId
drop proc GetAllShiftsWithFreeIntervalsOnCurrentService
drop proc GetAllFreeIntervalsInCurrentShiftOnCurrentService
drop proc GetAllFreeIntervalsOnCurrentService
drop proc CreateNewOrder
drop proc GetOrdersForClientById
drop proc UpdateOrderTimeForClientById
drop proc RemoveOrderForClientByOrderId
