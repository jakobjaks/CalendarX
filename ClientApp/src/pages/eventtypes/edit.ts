import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {EventTypeService} from "../../services/eventtype-service";
import {IEventType} from "../../interfaces/IEventType";

export var log = LogManager.getLogger('EventType.Delete');

@autoinject
export class Delete {

  private EventType: IEventType;

  constructor(
    private router: Router,
    private EventTypeService: EventTypeService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============
  submit():void{
    log.debug('EventType', this.EventType);
    this.EventTypeService.put(this.EventType!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("EventTypesIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
  }


  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);

    this.EventTypeService.fetch(params.id).then(
      EventType => {
        log.debug('EventType', EventType);
        this.EventType = EventType;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
