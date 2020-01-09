import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {EventService} from "../../services/events-service";
import {IEvent} from "../../interfaces/IEvent";

export var log = LogManager.getLogger('ContactTypes.Details');

@autoinject
export class Details {

  private event: IEvent | null = null;
  private file: string;

  constructor(
    private router: Router,
    private eventService: EventService
  ) {
    log.debug('constructor');
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
    this.eventService.fetch(params.id).then(
      event => {
        log.debug('event', event);
        this.event = event;
        this.file = "https://localhost:5001/images/" + event.imageSrc;
        console.log(this.file)
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
