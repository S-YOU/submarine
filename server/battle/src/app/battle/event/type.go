package event

// Type represents a specific value for battle event types.
type Type int

// Type constants.
const (
	ActorCreate Type = iota + 1
	ActorDestroy

	ActorAdd
	ActorMove
	ActorRemove

	AccelerationRequest
	BrakeRequest
	TurnRequest
	TorpedoRequest
	PingerRequest
)