$(function(){$("#external-events .fc-event").each(function(){$(this).data("eventObject",{title:$.trim($(this).text()),className:$(this).attr("data-bg"),stick:!0});$(this).draggable({zIndex:999,revert:!0,revertDuration:0})});var a=new Date,e=a.getDate(),b=a.getMonth();a=a.getFullYear();$("#calendar").fullCalendar({header:{left:"prev, next",center:"title",right:"today, month, agendaWeek, agendaDay"},events:[{title:"Daily meet",start:new Date(a,b,1),end:new Date(a,b,2),className:"purple-bg"},{id:999,
title:"Football",start:new Date(a,b,e-3,15,0),allDay:!1,className:"fb-bg"},{title:"Clients",start:new Date(a,b,13),end:new Date(a,b,14),className:"blue-bg"},{title:"Business",start:new Date(a,b,9),end:new Date(a,b,10),className:"orange-bg"},{title:"Meeting",start:new Date(a,b,28),end:new Date(a,b,29),className:"tw-bg"},{title:"Movie",start:new Date(a,b,3),end:new Date(a,b,4),className:"tw-bg"},{title:"Party",start:new Date(a,b,25),end:new Date(a,b,26),className:"red-bg"},{title:"Updates",start:new Date(a,
b,22),end:new Date(a,b,24),className:"pink-bg"},{title:"Seminar",start:new Date(a,b,18),end:new Date(a,b,19),className:"green-bg"},{title:"Investors",start:new Date(a,b,16),end:new Date(a,b,16),className:"fb-bg"},{title:"UX Dev",start:new Date(a,b,31),end:new Date(a,b,31),className:"orange-bg"}],editable:!0,eventLimit:!0,droppable:!0,drop:function(a,b){var c=$(this).data("eventObject");c=$.extend({},c);c.start=a;c.allDay=b;$("#calendar").fullCalendar("renderEvent",c,!0);$("#drop-remove").is(":checked")&&
$(this).remove()}});$("#createEvent").on("submit",function(a){a.preventDefault();a=$(this).find(".new-event-form");var b=a.val(),c=$(".event-tag  span.selected").attr("data-tag");if(3<=b.length){var d="new"+Math.random().toString(36).substring(7);$("#external-events .checkbox").before('<div id="'+d+'" class="fc-event '+c+'" data-bg="'+c+'">'+b+'<span class="fa fa-close remove-event"></span></div>');b={title:$.trim($("#"+d).text()),className:$("#"+d).attr("data-bg"),stick:!0};$("#"+d).data("eventObject",
b);$("#"+d).draggable({revert:!0,revertDuration:0,zIndex:999});a.val("").focus()}else a.focus()})});